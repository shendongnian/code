    public static void ComputeTimings(Action method, string methodName)
    {
        var sw = Stopwatch.StartNew();
        method();
        sw.Stop();
        Debug.WriteLine("Method {0} took {1}", methodName, sw.Elapsed);
    }
