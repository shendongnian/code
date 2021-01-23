    var stepCount = 0;
    Enumerable.Range(0, 10).AsParallel().WithDegreeOfParallelism(3).ForAll(i =>
        {
            var thisCount = Interlocked.Increment(ref stepCount);
            Console.WriteLine("{0} : {1} : {2}", i, lines[i], thisCount);
            ////Thread.Sleep(5000);
        }
  
        Console.ReadLine();
    }
