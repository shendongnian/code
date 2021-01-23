    private class DisposableTest : IDisposable
    {
        public string Name { get; set; }
        public void Dispose() { Console.WriteLine("{0}.Dispose() is called !", Name); }
    }
    public static void Main(string[] args)
    {
        try
        {
            UsingReturnTest();
            UsingExceptionTest();                
        }
        catch { }
        try
        {
            DisposeReturnTest();
            DisposeExceptionTest();                
        }
        catch { }
        DisposeExtraTest();
        Console.ReadLine();
    }        
