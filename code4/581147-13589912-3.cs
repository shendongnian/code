    using System.Diagnostics;
    //...
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < N_ITER; i++) {
        // cpu intensive sequence
    }
    stopwatch.Stop();
    elapsed_time = stopwatch.ElapsedMilliseconds;
