                    //Suppose you have DataTable dt
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                              @"Data Source='Give path of your access database file here';Persist Security Info=False";
                    OleDbConnection dbConn = new OleDbConnection(connectionString);
                    dbConn.Open();
                    using (dbConn)
                    {
                        int j = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            OleDbCommand cmd = new OleDbCommand(
                            "INSERT INTO Participant_Profile ([column1], [column2] , [column3] ) VALUES (@c1 , @c2 , @c3 )", dbConn);
                            cmd.Parameters.AddWithValue("@c1", dt.rows[i][j].ToString());
                            cmd.Parameters.AddWithValue("@c2", dt.rows[i][j].ToString());
                            cmd.Parameters.AddWithValue("@c3", dt.rows[i][j].ToString());
                            cmd.ExecuteNonQuery();
                            j++;
                        }
                    
                    }
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
