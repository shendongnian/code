    con.ConnectionString = sqlconn;
    var commands = File.ReadAllText(filenameScript).Split("GO");
    con.Open();
    foreach(var batch in commands)
    {
        SqlCommand command = new SqlCommand(batch, con);
        command.ExecuteNonQuery();
    }
    con.Close()
