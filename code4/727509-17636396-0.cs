        MySqlConnection sqlConn = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        string sSql = "SELECT id FROM caregiverdatabse WHERE name Like '%" + caregiverNameDisp.Text + "%'";
        sqlConn.ConnectionString = "Server=" + server + ";" + "Port=" + port + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Password=" + password + ";";
        sqlCmd.CommandText = sSql;
        sqlCmd.CommandType = CommandType.Text;
        sqlConn.Open();
        sqlCmd.Connection = sqlConn;
        MySqlDataReader reader = sqlCmd.ExecuteReader();
        List<string> results = new List<string>();
        while (reader.Read())
        {
            results.Add((reader["id"].ToString());
        }
        reader.Close();
        sqlConn.Close();
