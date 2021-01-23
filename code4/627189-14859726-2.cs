    try
    {
        await Task.Factory.StartNew(() => {
               // long running process
               throw new Exception("test"); // throwing TestException
            }, TaskCreationOptions.LongRunning);
    }
    catch(Exception error)
    {
          MyErrorHandler(error);
    }
