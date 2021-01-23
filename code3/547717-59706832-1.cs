    public List<List<Dictionary<string, object>>> ExecuteSqlReader(string cmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
            {
               var sqlCmd = new SqlCommand(cmd);
               var allRecord = new List<List<Dictionary<string, object>>>();
                using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
                {
                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var result = new List<Dictionary<string, object>>();
                            while (reader.Read())
                            {
                                result = GetTableRowData(reader);
                            }
    
                            allRecord.Add(result);
                        }
                        while (reader.NextResult())
                        {
                            if (reader.HasRows)
                            {
                                var result = new List<Dictionary<string, object>>();
                                while (reader.Read())
                                {
                                    result = GetTableRowData(reader);
                                }
                                allRecord.Add(result);
                            }
                        }
                    }
                }
                return allRecord;
            }
