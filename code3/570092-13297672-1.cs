    class Program
    {
        static void Main(string[] args)
        {
            CacheManager cache = new CacheManager();
            cache.AddOrGetExisting("item", () => new Test());
            // let one thread modify the item
            ThreadPool.QueueUserWorkItem(s =>
            {
                Thread.Sleep(250);
                cache.Update<Test>("item", i =>
                {
                    i.First = "CHANGED";
                    Thread.Sleep(500);
                    i.Second = "CHANGED";
                    return i;
                });
            });
            // let one thread just read the item and print it
            ThreadPool.QueueUserWorkItem(s =>
            {
                var item = ((Lazy<object>)cache.Get("item")).Value;
                Log(item.ToString());
                Thread.Sleep(500);
                Log(item.ToString());
            });
            Console.Read();
        }
        class Test
        {
            private string _first = "Initial value";
            public string First
            {
                get { return _first; }
                set { _first = value; Log("First", value); }
            }
            private string _second = "Initial value";
            public string Second
            {
                get { return _second; }
                set { _second = value; Log("Second", value); }
            }
            public override string ToString()
            {
                return string.Format("--> PRINTING: First: [{0}], Second: [{1}]", First, Second);
            }
        }
        private static void Log(string message)
        {
            Console.WriteLine("Thread {0}: {1}", Thread.CurrentThread.ManagedThreadId, message);
        }
        private static void Log(string property, string value)
        {
            Console.WriteLine("Thread {0}: {1} property was changed to [{2}]", Thread.CurrentThread.ManagedThreadId, property, value);
        }
    }
