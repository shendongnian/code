    private static void Main(string[] args)
    {
        Action action = () =>
        {
            using (var context = Context.Instance())
            {
                Console.WriteLine("Thread {0} - Context Id {1}", Thread.CurrentThread.ManagedThreadId, context.Id);
                using (var context2 = Context.Instance())
                {
                    Console.WriteLine("Thread {0} - Context Id {1}", Thread.CurrentThread.ManagedThreadId, context.Id);
                }
            }
            Thread.Sleep(1000);
        };
        Task.Factory.StartNew(action);
        Task.Factory.StartNew(action);
        Console.ReadLine();
    }
