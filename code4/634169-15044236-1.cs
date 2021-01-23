                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO survey (gender, age, birthplace, occupation, winner) VALUES ('" + sex  + ", " + likes + ", " + edu + ", " + userage + "')", mycon);
                    mycon.Open();
                    cmd.ExecuteNonQuery();
                }
    
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
    
                finally
                {
                    mycon.Close();
                }
