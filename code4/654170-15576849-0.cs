    class Program
    {
        static void Main(string[] args)
        {
            var token = new CancellationTokenSource();
            var t = Task.Factory.StartNew(
                o =>
                {
                    while (true)
                        Console.WriteLine("{0}: Processing", DateTime.Now);
                }, token);
            token.CancelAfter(1000);
            t.Wait(token.Token);
        }
    }
