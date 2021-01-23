    class Program
    {
        static void Main(string[] args)
        {
            MySingleton.Init();
            Thread.Sleep(7000);
            Console.WriteLine("Getting instance...");
            var mySingleton = MySingleton.Instance;
            Console.WriteLine("Got instance.");
        }
        public class MySingleton
        {
            private static Lazy<MySingleton> instance;
            public static MySingleton Instance
            {
                get { return instance.Value; }
            }
            public static void Init()
            {
                var initTask = Task.Factory.StartNew(() =>
                {
                    for(int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Doint init stuff {0}...", i);
                    }
                    return new MySingleton();
                });
                instance = new Lazy<MySingleton>(() => initTask.Result);
            }
            private MySingleton() { }
        }
    }
