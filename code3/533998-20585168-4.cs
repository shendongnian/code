        public async void Go()
        {
            Console.WriteLine("Start fosterage...");
            var t1 = Sleep(5000, "Kevin");
            var t2 = Sleep(3000, "Jerry");
            var result = await Task.WhenAll(t1, t2);
    
            Console.WriteLine($"My precious spare time last for only {result.Max()}ms");
            Console.WriteLine("Press any key and take same beer...");
            Console.ReadKey();
        }
    
        private static async Task<int> Sleep(int ms, string name)
        {
                Console.WriteLine($"{name} going to sleep for {ms}ms :)");
                await Task.Delay(ms);
                Console.WriteLine("${name} waked up after {ms}ms :(";
                return ms;
        }
