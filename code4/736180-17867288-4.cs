    interface I
    {
        Task FooAsync();
    }
    static void Main(string[] args)
    {
        I i = null;
        i.FooAsync();             // Does not warn
        // await i.FooAsync();    // Can't await in a non async method
        var t1 = i.FooAsync();    // Does not warn
        Task.Run(async () =>
        {
           i.FooAsync();          // Warns CS4014
           await i.FooAsync();    // Does not warn
           var t2 = i.FooAsync(); // Does not warn
        });
    }
