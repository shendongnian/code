    try
    {
        callee(..);
    }
    catch (SomeException e)
    {
       if (e.Message == "Sending file failed")
       {
          // what would you do here?
       }
    }
