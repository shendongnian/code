    messages.
        Buffer(() => feedback).
        Select(l => l.LastOrDefault()).
        ObserveOn(Scheduler.ThreadPool).
        Subscribe(n =>
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(250));
            Console.WriteLine(n);
            feedback.OnNext(Unit.Default);
        });
    
    feedback.OnNext(Unit.Default);
