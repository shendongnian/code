    public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        // Here, I can just replace the CommandText on the DbCommand - but remember I
        // want to only do it on MyContext
        var context = contexts.FirstOrDefault() as MyContext;
        if (context != null)
        {
            command.CommandText = command.CommandText
                .Replace("[dbo].[ReplaceMe1]", "[Database1].[dbo].[Customers]")
                .Replace("[dbo].[ReplaceMe2]", "[Database2].[dbo].[Addresses]")
                .Replace("[dbo].[ReplaceMe3]", "[Database3].[dbo].[Sales]");
        }
        
        base.ReaderExecuting(command, interceptionContext);
    }
