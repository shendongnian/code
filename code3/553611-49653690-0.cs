    using (SqlConnection sqlcon = new SqlConnection("Connection String HERE"))
            {
                using (SqlCommand sqlcmd= new SqlCommand())
                {
                    sqlcmd.Connection = sqlcon;            
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = "SELECT SUM(ItemRate) FROM logs WHERE RoomNo=@rno";
                    slqcmd.Parameters.AddWithValue("@rno", rno);
                    try
                    {
                        sqlcon.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Your Error Here");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
