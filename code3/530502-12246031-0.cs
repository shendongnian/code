    IDatabaseConnectivityObject databaseConnectivityObject = new DbProviderFactoryConnectionBasicResponse();
    try
    {
        try
        {
            Foo();
        }
        catch(ArgumentNullException e)
        {
            throw;
        }
    }
    finally
    {
      if(databaseConnectivityObject != null)//this test is often optimised away
        databaseConnectivityObject.Dispose()
    }
