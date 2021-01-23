    IDisposable subscription = 
        Observable
            .Interval(TimeSpan.FromHours(1))
            .Take(1)
            .Subscribe(i =>
    {
        Console.WriteLine("I'm doing something delayed by an hour");
    });
 
