    class Program
    {
        private static int _forwardsCount = 0;    // counters to simulate a "find"
        private static int _backwardsCount = 0;   // counters to simulate a "find"
        static void Main(string[] args) {
            var searchItem = "foo";
            var tokenSource = new CancellationTokenSource();
            var allDone = tokenSource.Token;
            Task t1 = Task.Factory.StartNew(() => DoSearchWithBarrier(SearchForwards, searchItem, tokenSource, allDone), allDone);
            Task t2 = Task.Factory.StartNew(() => DoSearchWithBarrier(SearchBackwards, searchItem, tokenSource, allDone), allDone);
            Task.WaitAll(new[] {t2, t2});
            Console.WriteLine("all done");
        }
        private static void DoSearchWithBarrier(Func<string, bool> searchMethod, string searchItem, CancellationTokenSource tokenSource, CancellationToken allDone) {
            while (!searchMethod(searchItem)) {
                if (allDone.IsCancellationRequested) {
                    return;
                }
            }
            tokenSource.Cancel();
        }
        ...
    }
