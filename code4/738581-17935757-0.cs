        static void Foo()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Foo called asynchronously!");
        }
        static void Main(string[] args)
        {
            var bar = Task.Factory.StartNew(() => { Foo(); });
            Console.WriteLine("Called synchronously!");
            Console.ReadLine();
        }
