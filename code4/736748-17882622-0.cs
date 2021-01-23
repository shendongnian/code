    try
    {
        var test = 10;
        throw new ReflectionTypeLoadException(new Type[] { test.GetType() }, new Exception[] { new FileNotFoundException() });
    }
    catch (ReflectionTypeLoadException ex)
    {
       var whatIsTheException = ex;
    }
