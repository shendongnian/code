            using (OdbcConnection odbcConnection = new OdbcConnection(db2ConnectionString))
            {
                odbcConnection.Open();
		//     string commandText = "";
                using (OdbcCommand command = new OdbcCommand(commandText, odbcConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@NATIONAL_ID", encryptedSSN);
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }
