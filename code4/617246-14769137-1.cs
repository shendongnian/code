        static void Main(string[] args)
        {
            SomeMethod();
            GC.Collect(GC.MaxGeneration);
            GC.WaitForFullGCComplete();
            Console.WriteLine("All done.");
            Console.ReadLine();
        }
        static void SomeMethod()
        {
            var obj2 = new FinalizerObject(1);
            var obj3 = new FinalizerObject(2);
        }
