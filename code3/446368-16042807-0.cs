    // assume you have a table with one column;
    string commandText = "insert into t_test1 (myid) values (@tempid)";
    using (MySqlConnection cn = new MySqlConnection(myConnectionString))
    {
        cn.Open();
        using (MySqlCommand cmd = new MySqlCommand(commandText, cn))
        {
            cmd.UpdatedRowSource = UpdateRowSource.None;
            cmd.Parameters.Add("?tempid", MySqlDbType.UInt32).SourceColumn = "tempid";
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.InsertCommand = cmd;
            // assume DataTable dt contains one column with name "tempid"
            int records = da.Update(dt);
        }
        cn.Close();
    }
