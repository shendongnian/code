    DataTable dt = new DataTable();
    using (MySqlConnection Conn = new MySqlConnection(connectionStr))
    {
        Conn.Open();
        string cmdStr = string.Format("{0} `{1}`", "SELECT * FROM", "yourtable");
        using (MySqlCommand cmdSel = new MySqlCommand(cmdStr, Conn))
        using (MySqlDataAdapter da = new MySqlDataAdapter(cmdSel))
            da.Fill(dt);
    }
    TableFromMySql = dt.DefaultView;
