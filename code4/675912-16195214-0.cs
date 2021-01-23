    private async void button1_Click(object sender, EventArgs e)
    {
        if (!r.TryLock())
            throw InvalidOperationException("Resource already acquired");
        try
        {
            var task = _IndependentResourceModiferAsync();
            // Mess with r here
            await task;
        }
        finally
        {
            r.Unlock();
        }
    }
