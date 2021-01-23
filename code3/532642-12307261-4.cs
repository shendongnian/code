    private static void TestWithResetEvent(string[] urls)
    {
        ManualResetEvent resetEvent = new ManualResetEvent(false);
        int counter = urls.Length;
        foreach (string url in urls)
        {
            string copy = url;
            Thread t = new Thread(() =>
            {
                TestWebWorking(copy);
                if (Interlocked.Decrement(ref toProcess) == 0))
                {
                    resetEvent.Set();
                }
            });
            t.Start();
        }
        resetEvent.WaitOne();
        Console.WriteLine("Done inside!!");
    }
