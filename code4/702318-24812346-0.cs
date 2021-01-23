    const string sql = @"select :parameter2, :parameter1 from dual";
    using (var cmd = new OracleCommand(sql, conn))
    using (cmd.Parameters.Add(":parameter1", "FOO"))
    using (cmd.Parameters.Add(":parameter2", "BAR"))
    using (var reader = cmd.ExecuteReader()) {
        reader.Read();
        // should print "FOOBAR"
        Console.WriteLine("{0}{1}", reader.GetValue(0), reader.GetValue(1));
    }
    using (var cmd = new OracleCommand(sql, conn) { BindByName = true })
    using (cmd.Parameters.Add(":parameter1", "FOO"))
    using (cmd.Parameters.Add(":parameter2", "BAR"))
    using (var reader = cmd.ExecuteReader()) {
        reader.Read();
        // should print "BARFOO"
        Console.WriteLine("{0}{1}", reader.GetValue(0), reader.GetValue(1));
    }
