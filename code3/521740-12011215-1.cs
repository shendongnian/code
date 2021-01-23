    var ur = new UnmanagedResource()
    try
    {        
        if( SomeCondition == true ){
            return SomeReturnValue;
        }
    }
    finally
    {
       ur.Dispose();
    }
