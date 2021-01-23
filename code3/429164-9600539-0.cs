    try
    {
        var yourObject = new SomeIDisposable();
        // Some code using yourObject
    }
    finally
    {
        yourObject.Dispose();
    }
