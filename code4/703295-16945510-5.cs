    static void Main()
    {
        var tasks = new[]
            {
                Task.Factory.StartNew(() => YourFunction()),
                Task.Factory.StartNew(() => YourFunction()),
                Task.Factory.StartNew(() => YourFunction())
            };
        Task.WaitAll(tasks)
    }
    public static string YourFunction()
    {
        var yourClass = new MyClass(GetValueFromDB());
        return yourClass.GetData();
    }
