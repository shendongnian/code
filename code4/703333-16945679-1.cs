    // once tasks are started
    TaskFactory.ContinueWhenAll(
        tasks,
        results =>
        {
            foreach (var t in results)
            {
                if (t.IsCompleted)
                    listBox.Items.Add(t.Result);
            }
        },
        cts.Token,
        TaskContinuationOptions.None,
        TaskScheduler.FromCurrentSynchronizationContext());
