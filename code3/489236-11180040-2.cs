    SynchronizationContext context = SynchronizationContext.Current;
    Task[] tasks = Enumerable.Range(2, 19)
        .Select(d => Task<double>.Factory.StartNew(() => SumRootN(d))
            .ContinueWith(t => {
                this.statusText.Text += string.Format("root {0} : {1}\n", d, t.Result);
            }))
        .ToArray();
        
    Task.Factory.StartNew(() => {
        Task.WaitForAll(tasks);
        string msg = string.Format("{0}ms elapsed\n", watch.ElapsedMilliseconds);
        context.Post(_ => { this.statusText.Text += msg; }, null);
    });
