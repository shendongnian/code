    Task.Factory.StartNew(() => {
        while (!dataItems.IsCompleted)
        {
            ValueEntry ve = null;
            try
            {
        ve = dataItems.Take();
        long microseconds = sw[ve.Value].ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
        results[ve.Value] = microseconds;
        //Console.WriteLine("elapsed microseconds = " + microseconds);
        //Console.WriteLine("Event handled: Value = {0} (processed event {1}", ve.Value, ve.Value);
            }
            catch (InvalidOperationException) { }
        }
    }, TaskCreationOptions.LongRunning);
    for (int i = 0; i < length; i++)
    {
        var valueToSet = i;
        ValueEntry entry = new ValueEntry();
        entry.Value = valueToSet;
        sw[i].Restart();
        dataItems.Add(entry);
        //Console.WriteLine("Published entry {0}, value {1}", valueToSet, entry.Value);
        //Thread.Sleep(1000);
    }
