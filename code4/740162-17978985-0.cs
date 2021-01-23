    try
    {
        context.Configuration.LazyLoadingEnabled = false;
        // run a query and materialize it here (with .ToList(), or .First(), etc.)
    }
    finally
    {
        context.Configuration.LazyLoadingEnabled = true;
    }
