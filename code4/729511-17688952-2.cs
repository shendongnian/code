    public static void Main(string[] args)
    {
        int num = 5;
        string str = "Helllllllllllo";
        Task<bool> taskObj = Task.Run<bool>(() => TestMethod(num, str));
        bool result2 = taskObj.Result;
        Console.WriteLine("Result: {0}", result2);
    }
