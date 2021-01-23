    class Foo
    {
        public bool Complete; // { get; set; }
    }
    class Program
    {
        static Foo foo = new Foo();
        static void ThreadProc()
        {
            bool toggle = false;
            while (!foo.Complete) toggle = !toggle;
            Console.WriteLine("Thread done");
        }
        static void Main()
        {
            var t = new Thread(ThreadProc);
            t.Start();
            Thread.Sleep(1000);
            foo.Complete = true;
            t.Join();
        }
    }
