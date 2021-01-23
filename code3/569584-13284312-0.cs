            internal static MySqlConnection GetConnection(string dbserver, string username, string password, string databasename)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=" + dbserver + ";User Id=" + username + ";Password=" + password + ";Persist Security Info=True;database=" + databasename);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // Code to handle exception
            }
        }
