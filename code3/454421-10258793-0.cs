    var a = Stopwatch.StartNew(); // Initializes and starts running
    var b = new Stopwatch(); // Initializes and doesn't start running
    var c = a.Elapsed; // TimeSpan
    
    a.Stop();
    a.Start();
    a.Reset();
