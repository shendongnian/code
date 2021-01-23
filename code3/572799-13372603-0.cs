    foreach (var command in commands)
    {
        try
        {
            command.Execute();
        }
        finally
        {
            Factory.Release(command);
        }
    }
