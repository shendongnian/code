     private bool do_check_password(string username, string oldPassword)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
                MySqlCommand dCmd = new MySqlCommand();
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    dCmd.CommandText = "select password from tbl_login WHERE username = ?username and password=?oldPassword";
                    dCmd.Parameters.Add(new MySqlParameter("?username", username));
                    dCmd.Parameters.Add(new MySqlParameter("?oldPassword", oldPassword));
                    dCmd.CommandType = CommandType.Text;
                    dCmd.Connection = mysqlCon;
                    dCmd.ExecuteNonQuery();
                    mysqlCon.Close();
                    MySqlDataAdapter da = new MySqlDataAdapter(dCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
    
                    
                    //string currentPassword = dt.Rows[0].ToString();
                    //return currentPassword;
                }
    
            } 
