        static void Main(string[] args)
        {
            SomeMethod();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForFullGCComplete();
            Thread.Sleep(1000);
            lock (lockObject)
            {
                Console.WriteLine("All done.");
            }
            Console.ReadLine();
        }
        static object lockObject = new Program();
        static void SomeMethod()
        {
            var obj2 = new FinalizerObject(1, lockObject);
            var obj3 = new FinalizerObject(2, lockObject);
        }
        [...]
        ~FinalizerObject()
        {
            lock (lockObject) { while (true) { Console.WriteLine("Finalizing {0}...", n); System.Threading.Thread.Sleep(1000); } }
        }
