    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var t = Task.Run(() => DoWork());
        t.ContinueWith(
            // take the result of the Task and update the UI
            completedTask => Output.Text = completedTask.Result.ToString()
            // tell the Task Continuation to run on the original UI context
            , TaskScheduler.FromCurrentSynchronizationContext()
            );
    }
    private int DoWork()
    {
        return 1;
    }
