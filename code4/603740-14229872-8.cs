    var sqlCommandFactory = new SqlCommandFactory();
    using (ISqlCommand command = sqlCommandFactory.CreateSqlCommand(query))
    {
        command.ExecuteReader();
    }
