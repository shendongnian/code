    void Button_Click(object sender, RoutedEventArgs e)
    {
        var t = StartAndWaitProcess(@"some\document\path");
        t.ContinueWith(dummy => b.Content = "process finished",
                       TaskScheduler.FromCurrentSynchronizationContext());
    }
    Task StartAndWaitProcess(string path)
    {
        var p = new Process();
        p.StartInfo.FileName = path;
        p.EnableRaisingEvents = true;
        var tcs = new TaskCompletionSource<bool>();
        p.Exited += (sender, args) => tcs.SetResult(true);
        p.Start();
        return tcs.Task;
    }
