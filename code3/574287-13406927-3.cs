    MyClass.WhenAll(pingTasks)
        .ContinueWith(t =>
        {
            foreach (var pingTask in pingTasks)
            {
                //pingTask.Result is whatever type T was declared in PingAsync
                textBox1.Text += Convert.ToString(pingTask.Result.RoundtripTime) + Environment.NewLine;
            }
        }, CancellationToken.None,
        TaskContinuationOptions.None,
        //this is so that it runs in the UI thread, which we need
        TaskScheduler.FromCurrentSynchronizationContext());
