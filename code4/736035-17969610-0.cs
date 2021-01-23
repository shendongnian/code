    static void Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        Observable.
            Interval(TimeSpan.FromSeconds(15)).
            Subscribe(_ => getData(), cts.Token));
        cts.CancelAfter(TimeSpan.FromSeconds(20));
    }
