    MyClass c = new MyClass();
    try
    {
        // Do some work with 'C'
    }
    finally
    {
        if (c != null)
            ((IDisposable)c).Dispose();
    }
