    IResult results;
    try
    {
      results = Entites.Customers.Where(x=>x.IsActive).Invoke();
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
