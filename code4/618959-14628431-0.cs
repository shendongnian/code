    public static void Verify(IInterface objectToVerify)
    {
        if (!(objectToVerify is TestClass))
        {
            Debug.Assert(false, "Passed object must be type of TestClass");
            return;
        }
        // do something ...
    }
