        public async Task ExecuteScript(string _connectionString, string script)
        {
            using (StringReader sr = new StringReader(script))
            {
                var connection = new OracleConnection(_connectionString);
                connection.Open();
                string sqlCommand = "";
                string sqlLine; byte lineNum = 0;
                while ((sqlLine = sr.ReadLine()) != null)
                {
                    sqlLine = sqlLine.Trim(); ++lineNum;
                    if (sqlLine.Length > 0 && !sqlLine.StartsWith("--"))
                    {
                        sqlCommand += sqlCommand.Length > 0 ? Environment.NewLine : "" + sqlLine;  // Accepts multiline SQL
                        if (sqlCommand.EndsWith(";"))
                        {
                            sqlCommand = sqlCommand.Substring(0, sqlLine.Length - 1);
                            var command = new OracleCommand(sqlCommand, connection);
                            try
                            {
                                await command.ExecuteNonQueryAsync(); 
                                if (command.Transaction != null)
                                    command.Transaction.Commit();
                            }
                            catch (OracleException ex)
                            {
                                connection.Close();
                                var e2 = new Exception($"{lineNum} - {sqlCommand} <br/> {ex.Message}");
                                throw e2;
                            }
                        }
                    }
                }
                connection.Close();
                return;
            }
        }
