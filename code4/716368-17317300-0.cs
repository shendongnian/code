    MyDisposable myDisposable = new MyDisposable(new AnotherDisposable());
    try
    {
        //whatever
    }
    finally
    {
        if (myDisposable != null)
            myDisposable.Dispose();
    }
