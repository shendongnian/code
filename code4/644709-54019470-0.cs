    public async Task RunUntilCancellation(
        CancellationToken cancellationToken,
        Func<Task> onCancel)
    {
        var doneReceiving = new TaskCompletionSource<bool>();
         
        cancellationToken.Register(
            async () =>
            {
                await onCancel();
                doneReceiving.SetResult(true); // Signal to quit message listener
            });
        await doneReceiving.Task.ConfigureAwait(false); // Listen until quit signal is received.
    }
