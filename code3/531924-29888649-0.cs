            string connection_String = @""; //your connection string
            try
            {
                using (SqlConnection con = new SqlConnection(connection_String))
                {
                    string sql = "INSERT INTO table_copy_to " +
                        "(column1, column2, column3 ... columnn) " +
                    "SELECT column1, column2, column3 ... column FROM table_copy_from";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        int rowEffected = cmd.ExecuteNonQuery();
                        if (rowEffected > 0)
                        {
                            Console.WriteLine("Excuted Successfully ...");
                        }
                        else
                        {
                            Console.WriteLine("Some problem occur");
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex);
            }
