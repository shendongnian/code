    SomeDisposableType obj = new SomeDisposableType();
    try
    {
        // use obj
    }
    finally
    {
        if (obj != null) 
            ((IDisposable)obj).Dispose();
    }
