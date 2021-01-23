    using System.Diagnotics;
    var stopWatch = new StopWatch();
    stopWatch.Start();
    // Do somthing
    // If somthing is really fast do lots of somthing
    stopWatch.Stop();
    // The duration is a TimeSpan in stopWatch.Elapsed;
