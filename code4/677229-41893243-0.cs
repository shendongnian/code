    public async Task<StringBuilder> FetchFileDetailsAsync(string filename, string subdirectory, string envId)
        {
            var sb = new StringBuilder();
            //TODO: Check the parameters
            const string connectionString = "user id=userid;password=secret;data source=" +
                                            "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=10.0.0.8)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)))";
            const string selectQuery = "SELECT * FROM EIP_Deployment_Files"
                                    + " WHERE Filename = :filename"
                                    + " AND Subdirectory = :subdirectory"
                                    + " AND Environment_ID = :envID"
                                    + " AND rownum<=1";
            using (var connection = new OracleConnection(connectionString))
            using (var cmd = new OracleCommand(selectQuery, connection) {BindByName = true, FetchSize = 1 /*As we are expecting only one record*/})
            {
                cmd.Parameters.Add(":filename", OracleDbType.Varchar2).Value = filename;
                cmd.Parameters.Add(":subdirectory", OracleDbType.Varchar2).Value = subdirectory;
                cmd.Parameters.Add(":envID", OracleDbType.Varchar2).Value = envId;
                //TODO: Add Exception Handling
                await connection.OpenAsync();
                var dataReader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                var rowValues = new object[dataReader.FieldCount];
                if (dataReader.Read())
                {
                    dataReader.GetValues(rowValues);
                    for (var keyValueCounter = 0; keyValueCounter < rowValues.Length; keyValueCounter++)
                    {
                        sb.AppendFormat("{0}:{1}", dataReader.GetName(keyValueCounter), 
                            rowValues[keyValueCounter] is DBNull ? string.Empty : rowValues[keyValueCounter])
                          .AppendLine();
                    }
                   
                }
                else
                {
                    //No records found, do something here
                }
                dataReader.Close();
                dataReader.Dispose();
            }
            return sb;
        }
