    public static void DoSomething()
    {
      try
      { 
        //some code
      }
        
      catch (ExceptionA e)
      {
        log.Error("At the end something is wrong: " + e);
        FunctionA(); //same function as in the first exception    
      }
      catch (ExceptionB e)
      {
        log.Error("At the start something wrong: " + e);
        FunctionA(); //same function as in the first exception    
      }
      finally
      {
            //you can do something here whether there is an exception or not
      }
    }
