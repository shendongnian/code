    var scheduler = new TestScheduler();
    scheduler.AdvanceTo(TimeSpan.FromTicks(100).Ticks);
    scheduler.Schedule(
        DateTime.MinValue + TimeSpan.FromTicks(50),
        () => Console.WriteLine("Hello"));
    Console.WriteLine("No output until the scheduler is given time...");
    scheduler.AdvanceBy(1);
