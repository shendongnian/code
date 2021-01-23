       if (sqlCon.State == System.Data.ConnectionState.Open)
                        {
                            insCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sqlCon.Open();
                            insCmd.ExecuteNonQuery();
                        }
                    }
