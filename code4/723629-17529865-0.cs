    public static DbTransaction BeginTransaction(this DbContext context, IsolationLevel isolationLevel)
    {
        if (context.Database.Connection.State != ConnectionState.Open)
            context.Database.Connection.Open();
        return context.Database.Connection.BeginTransaction(isolationLevel);
    }
