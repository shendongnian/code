        public string editUserPassword(string username, string oldPassword, string newPassword)
            {
    
                   try
                    {
                        
                        string connectionString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
                        MySqlCommand dCmd = new MySqlCommand();
                        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                        {
                            if(do_check_password(username, oldPassword) == true )              
                                {
                                    mysqlCon.Open();
                                    dCmd.CommandText = "UPDATE tbl_login SET password=?password WHERE username=?username";
                                    dCmd.CommandType = CommandType.Text;
                                    dCmd.Parameters.Add(new MySqlParameter("?username", username));
                                    dCmd.Parameters.Add(new MySqlParameter("?password", newPassword));    
                                    dCmd.Connection = mysqlCon;
                                    dCmd.ExecuteNonQuery();
                                    mysqlCon.Close(); 
                                }
                                else
    
                                {
                                    return string.Format( "invalid password");
                               }
                      }
                         return string.Format("password changed");
                      }
                    catch (Exception ex)
                    {
                        return string.Format(ex.Message);
                    }
    
    }
