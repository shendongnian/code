        static void Main(string[] args) {
            var timer = new Stopwatch();
            timer.Restart();
            for (int i = 0; i < 1000; i++)
                Test1("just a little test string.");
            timer.Stop();
            TimeSpan elapsed1 = timer.Elapsed;
            
            timer.Restart();
            for (int i = 0; i < 1000; i++)
                Test2("just a little test string.");
            timer.Stop();
            TimeSpan elapsed2 = timer.Elapsed;
            timer.Restart();
            for (int i = 0; i < 1000; i++)
                Test3("just a little test string.");
            timer.Stop();
            TimeSpan elapsed3 = timer.Elapsed;
            Console.WriteLine(elapsed1);
            Console.WriteLine(elapsed2);
            Console.WriteLine(elapsed3);
            Console.Read();
        }
