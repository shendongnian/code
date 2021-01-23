                        if (rdr.HasRows)
                        {
                            while(rdr.Read())
                            {
                                string fieldValue = rdr[0].ToString();
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
