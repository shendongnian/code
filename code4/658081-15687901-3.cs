    ILogger logger = ...;
    IResult results;
    try
    {
      results = Entites.Customers.Where(x=>x.IsActive=true).TryInvoke();
      if(results == null)
      {
        // something wrong
      }
    
      // OR
      results = Entites.Customers.Where(x=>x.IsActive=true).InvokeAndHandle(logger);
      if(results == null)
      {
        // something wrong
      }      
    }
    ...
    catch(Exception ex)
    {
      Log(ex, "Unknown error.");
    }
