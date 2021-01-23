    private static void PeriodicWait() {
        Stopwatch stopwatch = new Stopwatch();
        while (true) {
            stopwatch.Restart();
            _handle.Reset();
            bool result = _handle.WaitOne(5000);
            stopwatch.Stop();
            Console.WriteLine("After WaitOne: {0}. Waited for {1}ms", result ? "success" : "failure",
                                stopwatch.ElapsedMilliseconds);
        }
    }
    private static void PeriodicSignal() {
        while (true) {
            _handle.Set();
            Thread.Sleep(800);   // Simulate work
        }
    }
