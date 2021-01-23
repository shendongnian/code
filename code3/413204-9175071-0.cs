    public static Task<int> Do()
    {
        Contract.Ensures(Contract.Result<Task<int>>() != null);
        Contract.Ensures(Contract.Result<Task<int>>().Result > 0);
        return Task.Factory.StartNew(() => { Thread.Sleep(3000); return 2; });
    }
    public static void Main(string[] args)
    {
        var x = Do();
        Console.WriteLine("processing");
        Console.WriteLine(x.Result);
    }
