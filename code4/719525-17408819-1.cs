    public static async Task Foo()
    {
        string filename = await WhenFileCreated(@"C:\Temp\");
        Console.WriteLine(filename);
    }
