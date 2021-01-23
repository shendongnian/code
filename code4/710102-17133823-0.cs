    public void insertData()
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Sources(SourceID, SourceName, Active) VALUES(@SourceID, @SourceName, @Active)", con))
                        {
                            cmd.Parameters.Add(new SqlParameter("SourceID", mSourceID));
                            cmd.Parameters.Add(new SqlParameter("SourceName", mSourceName));
                            cmd.Parameters.Add(new SqlParameter("Active", mActive));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("Unable To Save Data. Error - " + Ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
