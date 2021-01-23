    CancellationTokenSource cts;
    bool loading;
    private void SelectedIndexChanged(int index)
    {
        if (loading)
            cts.Cancel();
        cts = new CancellationTokenSource();
        var loader = new Task.Delay(1000);
        loader.ContinueWith(() => LoadFile(index))
              .ContinueWith((x) => DisplayResult(x));
		
        loader.Start();
    }
    private void DisplayResult(Task t)
    {
        // TODO: Invoke this Method to MainThread
        if (!cts.IsCancellationRequested)
        {
            // Actually display this file
        }
    }
