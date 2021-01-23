    using (var command = new SqlCommand("InsertTable") {CommandType = CommandType.StoredProcedure})
    {
        var dt = new DataTable(); //create your own data table
        command.Parameters.Add(new SqlParameter("@myTableType", dt));
        SqlHelper.Exec(command);
    }
