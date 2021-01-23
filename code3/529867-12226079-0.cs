        static void Do()
        {
            Console.WriteLine("Inside " + _Counter);
            Thread.Sleep(1000);
            Console.WriteLine(_Counter + " is done");
        }
        static void Main(string[] args)
        {
            Task.Factory.StartNew(Do)
                .ContinueWith(t => Do())
                .ContinueWith(t => Do())
                .ContinueWith(t => Do());
        }
