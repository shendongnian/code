        static Random r = new Random();
        static void Main(string[] args) {
            var observ = GenerateNum(1000).ToObservable(Scheduler.ThreadPool );
            observ.Subscribe(
                (x) => Console.WriteLine("test:" + x),
                (Exception ex) => Console.WriteLine("Error received from source: {0}.", ex.Message),
                () => Console.WriteLine("End of sequence.")
                );
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) {
                Console.WriteLine("You pressed a key.");
            }
        } 
        static IEnumerable<int> GenerateNum(int sequenceLength) {
            for (int i = 0; i < sequenceLength; i++) {
                Thread.Sleep(r.Next(1, 200));
                yield return i;
            }
        }
