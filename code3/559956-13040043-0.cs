    float[] bestResult;
    object sync = new Object();
    var sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    lock (sync) 
    {
        sw.Stop();
        if (bestResult[0] > calculatedData[0]) {
            bestResult = calculatedData;
        }
    }
    Console.WriteLine("Time spent waiting: " + sw.Elapsed);
