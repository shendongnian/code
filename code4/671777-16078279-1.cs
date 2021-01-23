    con.ConnectionString = sqlconn;
    var commands = File.ReadAllText(filenameScript).Split(new []{"GO"},StringSplitOption.RemoveEmptyEntries);
    con.Open();
    foreach(var batch in commands)
    {
        SqlCommand command = new SqlCommand(batch, con);
        command.ExecuteNonQuery();
    }
    con.Close()
