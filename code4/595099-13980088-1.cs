    SomeType obj = new SomeType();
    try
    {
        // do stuff with obj
        // if an exception is thrown then the finally block takes over
    }
    finally
    {
        if(obj != null)
            obj.Dispose();
    }
