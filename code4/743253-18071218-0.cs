    public TaskCompletionSource<string> DoWorkInSequence()
    {
        var result = new TaskCompletionSource<string>();
        Task<int> AlphaTask = Task.Factory.StartNew(() => 4);
        Func<int> BravoFunc = x => 2 * x;
        //Prepare for Rx, and set filters to allow 'Zip' to terminate early
        //in some cases.
        IObservable<int> AsyncAlpha = AlphaTask.ToObservable().TakeWhile(x => x != 5);
        AsyncAlpha
            .Do(x => Console.WriteLine(x))  //This is how you "Do WORK in sequence"
            .Select(BravoFunc)              //This is how you map results from Alpha
                                            //via a second method.
            .Timeout(TimeSpan.FromMilliseconds(200)).Subscribe(
                (x) => { result.TrySetResult(x); },
                (x) => { result.TrySetException(x.GetBaseException()); },
                () => { result.TrySetResult("Nothing"); });
        return result;
    }
