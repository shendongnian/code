    void Method1()
    {
        try
        {
            Method2();
        }
        catch // this will catch *any* exception
        {
        }
    }
    void Method2()
    {
        try
        {
            Method3();
        }
        catch (COMException ex) // this will catch only COMExceptions and exceptions that derive from COMException
        {
        }
    }
    void Method3()
    {
        // if this code were here, it would be caught in Method2
        throw new COMException();
        // if this code were here, it would be caught in Method1
        throw new ApplicationException();
    }
