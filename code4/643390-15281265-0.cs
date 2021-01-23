    DbContext context = null;
    try
    {
        context = new DbContext();
        var query = context.GetStuff();
        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                context.SaveChanges();
            }
            finally
            {
                context.Dispose();
            }
        });
    }
    catch
    {
        //dispose of the context only if there was an exception, as it 
        //meant we weren't able to get into the async task and dispose of it there
        if (context != null)
            context.Dispose();
        throw;
    }
