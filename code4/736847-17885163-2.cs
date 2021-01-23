    IDisposable someObjectThatIsDispoable; // e.g. StreamWriter/StreamReader, et al
    try
    {
         // your code here
    }
    finally
    {
        if(someObjectThatIsDisposable != null)
            someObjectThatIsDisposable.Dispose();
    }
