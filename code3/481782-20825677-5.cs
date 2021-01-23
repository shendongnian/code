    private static string UsingReturnTest()
    {
        using (DisposableTest usingReturn = new DisposableTest() { Name = "UsingReturn" })
        {
            return usingReturn.Name;
        }
    }
    private static void UsingExceptionTest()
    {
        using (DisposableTest usingException = new DisposableTest() { Name = "UsingException" })
        {
            int x = int.Parse("NaN");
        }
    }
    private static string DisposeReturnTest()
    {        
        DisposableTest disposeReturn = new DisposableTest() { Name = "DisposeReturn" };
        return disposeReturn.Name;
        disposeReturn.Dispose(); // # IDE Warning; Unreachable code detected
    }
    private static void DisposeExceptionTest()
    {
        DisposableTest disposeException = new DisposableTest() { Name = "DisposeException" };
        int x = int.Parse("NaN");
        disposeException.Dispose();
    }
    private static void DisposeExtraTest()
    {
        DisposableTest disposeExtra = null;
        try
        {
            disposeExtra = new DisposableTest() { Name = "DisposeExtra" };
            return;
        }
        catch { }
        finally
        {
            if (disposeExtra != null) { disposeExtra.Dispose(); }
        }
    }
