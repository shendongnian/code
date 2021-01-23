    public static void Main(string[] args)
    {
        var program = new Program();
        var methodInfo = GetMethod<Program, EventArgs>(()=> program.Method);
        Console.WriteLine(methodInfo.Name);
    }
