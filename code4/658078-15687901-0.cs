    IResult result;
    try
    {
      results = Entites.Customers.Where(x=>x.IsActive=true).Invoke();
    }
    catch(YourOwnException ex)
    {
      Log(ex, "The Business logic error.");
    }
    catch(ArgumentException ex)
    {
      Log(ex, "Invalid arguments.")
    }
    ...
    catch(Exception ex)
    {
      Log(ex, "Unknown error.");
    }
