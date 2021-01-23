                string connetionString = null;
                SqlConnection cnn ;
                SqlCommand cmd ;
                string sql = null;
    
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                sql = "Your SQL Statemnt Here";
    
                cnn = new SqlConnection(connetionString);
                
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        //do anything
                    }
                    cmd.Dispose();
                    cnn.Close();
                    MessageBox.Show (" ExecuteNonQuery in SqlCommand executed !!");
