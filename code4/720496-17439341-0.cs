    try
    {
        dynamic testData = ReturnDynamic();
        var name = testData.Name;
        // do more stuff
    }
    catch (RuntimeBinderException)
    {
        //  MyProperty doesn't exist
    } 
