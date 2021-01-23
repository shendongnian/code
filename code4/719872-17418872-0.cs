    using System.Diagnostics;
    //...
    Stopwatch timer = new Stopwatch();
    timer.Start();
    while(timer.Elapsed.TotalSeconds < Xseconds)
    {
        // do something
    }
    timer.Stop();
