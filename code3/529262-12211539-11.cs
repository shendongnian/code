    public static void DoSomething()
    {
      try
      { 
        //some code
        try
        {
          //some other code
        }
        catch (Exception e)
        {
          log.Error("At the end something is wrong: " + e);
          throw;
        }
      }
      catch (Exception e)
      {
        log.Error("At the start something wrong: " + e);
        throw;
      }
    }
