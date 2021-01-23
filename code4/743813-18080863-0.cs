    public static int LookUpIntForSomething(IDbConnection connection)
    {
        using (var command = connection.CreateCommand())
        {
            // use command.
        }
    }
