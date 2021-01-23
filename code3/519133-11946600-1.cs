    var values = Observable.Generate(
            0,           // Initializer.
            i => i < 5,  // Condition.
            i => i + 1,  // Iteration.
            i => i,      // Result selector.
            i => TimeSpan.FromSeconds(1));
    var task = values
        .Do(i => { /* Perform action every second. */ })
        .ToTask();
    values.Wait();
