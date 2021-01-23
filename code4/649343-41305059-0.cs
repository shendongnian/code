        class CancelingTasks
    {
        private static void Foo(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(100);
                Console.Write(".");                
            }
        }
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken tok = source.Token;
            tok.Register(() =>
            {
                Console.WriteLine("Cancelled.");
            });
            Task t = new Task(() =>
            {
                Foo(tok);
            }, tok);
            t.Start();
            Console.ReadKey();
            source.Cancel();
            source.Dispose();
            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
