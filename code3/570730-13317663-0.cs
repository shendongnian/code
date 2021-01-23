    try
            {
                cmd.ExecuteNonQuery();  //this is for inserting or updating db
                cn.Close();
                MessageBox.Show("Login"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid");
            }     
