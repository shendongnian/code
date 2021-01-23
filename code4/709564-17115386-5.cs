    /// <summary>
    /// Awaits a fresh Task created by the <paramref name="heartbeatTaskFactory"/> once every <paramref name="heartbeatInterval"/> while <paramref name="primaryTask"/> is running.
    /// </summary>
    public static async Task WithHeartbeat(this Task primaryTask, TimeSpan heartbeatInterval, Func<CancellationToken, Task> heartbeatTaskFactory, CancellationToken cancellationToken) {
        if (cancellationToken.IsCancellationRequested) {
            return;
        }
    
        var stopHeartbeatSource = new CancellationTokenSource();
        cancellationToken.Register(stopHeartbeatSource.Cancel);
    
        await Task.WhenAny(primaryTask, PerformHeartbeats(heartbeatInterval, heartbeatTaskFactory, stopHeartbeatSource.Token));
        stopHeartbeatSource.Cancel();
    }
    
    private static async Task PerformHeartbeats(TimeSpan interval, Func<CancellationToken, Task> heartbeatTaskFactory, CancellationToken cancellationToken) {
        while (!cancellationToken.IsCancellationRequested) {
            await Task.Delay(interval, cancellationToken);
            if (!cancellationToken.IsCancellationRequested) {
                await heartbeatTaskFactory(cancellationToken);
            }
        }
    }
