    var commandFactory = new CommandFactory();
    using (ISqlCommand command = commandFactory.CreateSqlCommand(query))
    {
        command.ExecuteQuery();
    }
