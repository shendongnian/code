    var wrappedReaderType = typeof (Dapper.CommandDefinition)
                            .Assembly.GetType("Dapper.WrappedReader");
    var field = wrappedReaderType
                .GetField("cmd", BindingFlags.NonPublic | BindingFlags.Instance);
    if (field != null)
    {
        var command = field.GetValue(reader) as IDbCommand;
        if (command != null)
        {
            command.Cancel();
        }
    }
