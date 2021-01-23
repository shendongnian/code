    public static Task FooAsync()
    {
        Console.WriteLine("Started Foo");
        return Task.Delay(1000)
            .ContinueWith(t => Console.WriteLine("Finished Foo"));
    }
    public static Task BarAsync()
    {
        return Task.Factory.StartNew(() => { throw new Exception(); });
    }
    
    private static void Main(string[] args)
    {
        List<Func<Task>> list = new List<Func<Task>>();
    
        list.Add(() => FooAsync());
        list.Add(() => FooAsync());
        list.Add(() => FooAsync());
        list.Add(() => FooAsync());
        list.Add(() => BarAsync());
    
        Task task = ForEachAsync(list);
    
        task.ContinueWith(t => Console.WriteLine(t.Exception.ToString())
            , TaskContinuationOptions.OnlyOnFaulted);
        task.ContinueWith(t => Console.WriteLine("Done!")
            , TaskContinuationOptions.OnlyOnRanToCompletion);
    }
