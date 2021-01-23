    using(var con = new OracleConnection(conStr))
    using(var cmd = con.CreateCommand())
    {
        con.Open(); 
        cmd.CommandText = "insert into table1 values ('ss');
        if(cmd.ExecuteNonQuery() > 0)
        {
            Console.WriteLine("insert sucess!");
        }
    }
