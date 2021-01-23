                 string stringConnection = "Your connection to your database";
                using(var connection = new SqlConnection(stringConnection)
                {
                    connection.Open();
                
                    using (var command = new SqlCommand("sp_intranet_GetSecurity", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
    
                        command.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar));
                        command.Parameters["@username"].Value = "Your value";
    
                        command.Parameters.Add(new SqlParameter("@path", SqlDbType.VarChar, 8));
                        command.Parameters["@path"].Value = "Your value";
    
                        command.Parameters.Add(new SqlParameter("@errorID", SqlDbType.VarChar, 8));
                        command.Parameters["@errorID"].Value = "Your value";
                        command.Parameters["@errorID"].Direction = ParameterDirection.Output;
    
                        // Objet DataReader
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        Object[] row = null;
                        while (reader.Read())
                        {
                            if (row == null)
                            {
                                row = new Object[reader.FieldCount];
                            }
                            reader.GetValues(row);
                            for (int i = 0; i < row.GetLength(0); i++)
                            {
                                if (row[i] != DBNull.Value)
                                {
                                    Console.Write(row[i]);
                                }
                                else
                                {
                                    Console.Write("NULL");
                                }
                                if (i < row.GetUpperBound(0))
                                {
                                    Console.Write("|");
                                }
                            }
                        }
                
    
                   }
                }
