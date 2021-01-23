    public Task<string> DoWorkInSequence()
    {
        var cts = new CancellationTokenSource();
        Task timer = Task.Factory.StartNewDelayed(200, () => { cts.Cancel(); });
        Task<int> AlphaTask = Task.Factory
            .StartNew(() => 4 )
            .Where(x => x != 5 && !cts.IsCancellationRequested);
        Task<bool> BravoTask = AlphaTask
            .Then(x => true)
            .Where(x => x && !cts.IsCancellationRequested);
        Task<int> DeltaTask = BravoTask
            .Then(x => 7)
            .Where(x => x != 8);
        Task<string> final = Task.Factory
            .WhenAny(DeltaTask, timer)
            .ContinueWith(x => !DeltaTask.IsCanceled && DeltaTask.Status == TaskStatus.RanToCompletion
                ? AlphaTask.Result.ToString() + BravoTask.Result.ToString() + DeltaTask.Result.ToString(): "Nothing");
        //This is here just for experimentation.  Placing it at different points
        //above will have varying effects on what tasks were cancelled at a given point in time.
        cts.Cancel();
        return final;
    }
