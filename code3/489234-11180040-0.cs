    Task[] tasks = Enumerable.Range(2, 19)
        .Select(d => Task<double>.Factory.StartNew(() => SumRootN(d))
            .ContinueWith(t => {
                this.statusText.Text += string.Format("root {0} : {1}\n", d, t.Result);
            }, TaskScheduler.FromCurrentSynchronizationContext()))
        .ToArray();
        
    Task.Factory.StartNew(() => {
        Task.WaitForAll(tasks);
        this.statusText.Text += String.Format("{0}ms elapsed\n", watch.ElapsedMilliseconds);
    }, TaskScheduler.FromCurrentSynchronizationContext());
