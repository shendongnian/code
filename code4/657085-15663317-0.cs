            task.ContinueWith(t =>
        {
            // Is this code necessary to prevent a race condition?
            if (ct.IsCancellationRequested)
                return;
            int result = t.Result;
            if (ct.IsCancellationRequested)
                return;
            m_label.Text = result.ToString();
        }, ct, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
