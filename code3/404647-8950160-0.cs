    //try to log in and get SomeException  
    catch(SomeException ex)
    {
      ex.Data.Add("action", "Login");
      throw;
    }
    ...
    //try to send a file and get SomeException
    catch(SomeException ex)
    {
        ex.Data.Add("action", "Sending of file");
        throw;
    }
    ...
    // somewhere further up the call stack
    catch(SomeException ex)
    {
        var action = ex.Data["action"] ?? "Unknown action";
        Console.WriteLine("{0} failed.", action); // ... or whatever.
    }
