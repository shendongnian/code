    string command = "SELECT Something FROM SomeTable WHERE SomethingElse = '%" + "@Parameter1" + "%' AND SomethingElseStill LIKE '%" + @Parameter2 + "%' ";
    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        OdbcCommand command = new OdbcCommand(command, conn);
        command.Parameters.Add("@Parameter1", OdbcType.VarChar, 255);
        command.Parameters["@Parameter1"].Value = "SomeString"
        command.Parameters.Add("@Parameter2", OdbcType.Int);
        int SomeInteger = 1;
        command.Parameters["@Parameter2"].Value = SomeInteger;
        OdbcDataAdapter adapter = new OdbcDataAdapter(command,con);
        DataSet Data = new DataSet();
        adapter.Fill(Data);
    }
