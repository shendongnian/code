    IObservable<bool> ValidateAsync(Row item)
    {
        return Observable.Start(() => {
            // TODO: Figure out if the row is valid
            return true;
        }, Scheduler.TaskPoolScheduler);
    }
    myBigDataTable.ToObservable()
        .Select(x => ValidateAsync(x).Select(y => new { Row = x, IsValid = y }))
        .Merge(10 /* rows concurrently */)
        .ObserveOn(SynchronizationContext.Current /*assuming WinForms */)
        .Subscribe(x => {
            Console.WriteLine("Row {0} validity: {1}", x.Row, x.IsValid);
        });
