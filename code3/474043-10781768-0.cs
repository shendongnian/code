    System.Data.OracleClient.OracleParameter prm = new System.Data.OracleClient.OracleParameter();
                    prm.Direction = ParameterDirection.ReturnValue;
                    prm.DbType = DbType.AnsiString;
                    prm.Size = 16;
                    com1.Parameters.Add(prm);
    
                    
                    com1.CommandText = "TRB01.set_idoc('DOC','1','"
                                                       + sender + "','"
                                                       + reciver + "','"
                                                       + cre_date + "','"
                                                       + bod_ID + "')";
                    com1.ExecuteNonQuery();
    
                    Lidoc_num = com1.Parameters[0].Value.ToString();
