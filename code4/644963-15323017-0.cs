    var context = new DataContext();
 
    try
    { 
       if (!context.Database.Exists())
       {
           ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
       }
    }
    finally
    {
        if (context != null)
            context.Dispose();
    }
