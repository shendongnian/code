        using(MySqlConnection sqlCon = new MySqlConnection(MyConnectionString))
        {
            sqlCon.Open();
            MySqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT * FROM table1 WHERE username = ?user AND password = ?pwd";
            cmd.Parameters.AddWithValue("?user", userId);
            cmd.Parameters.AddWithValue("?pwd", password);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
        }
