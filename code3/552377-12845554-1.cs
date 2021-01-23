    var sw = new Stopwatch();
    List<long> totalTime = new List<long>();
    
    for (var u = 0; u < 100000; u++)
    {
        sw.Start();
        //logic here
        sw.Stop();
        totalTime.Add(sw.ElapsedMilliseconds);
        sw.Reset();
    }
    Console.WriteLine("Average time in Milliseconds: {0}", totalTime.Average());
