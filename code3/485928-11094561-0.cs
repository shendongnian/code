    private string do_check_password(string username)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mysql"].ToString();
                MySqlCommand dCmd = new MySqlCommand();
                using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    dCmd.CommandText = "select password from tbl_login WHERE username = ?username ";
                    dCmd.CommandType = CommandType.Text;
                    dCmd.Parameters.Add(new MySqlParameter("?username", username));
                    dCmd.Connection = mysqlCon;
                    //dCmd.ExecuteNonQuery(); no need here
                   
                    MySqlDataAdapter da = new MySqlDataAdapter(dCmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    mysqlCon.Close();
                    string currentPassword = dt.Rows[0].ToString();
                    return currentPassword;
                }
    
            }
