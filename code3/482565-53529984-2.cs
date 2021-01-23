    Stopwatch timer = Stopwatch.StartNew();
    Thread.Sleep(1234);
    timer.Stop();
    TimeSpan timeSpan = timer.Elapsed;
    Console.WriteLine("Total processing time... {0:00}:{1:00}:{2:00}.{3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    // OUTPUT   Total processing time... 00:00:01.243
		
