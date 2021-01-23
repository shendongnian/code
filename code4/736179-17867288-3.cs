    static void Main(string[] args)
    {
        Task.Run(async () =>
                           {
                               C c = new C();
                               c.FooAsync();
                               ((I) c).FooAsync();
                           });
    }
