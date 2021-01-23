    public static class TaskExtensions {
        /// <summary>
        /// Issues the <paramref name="heartbeatAction"/> once every <paramref name="heartbeatInterval"/> while <paramref name="primaryTask"/> is running.
        /// </summary>
        public static async Task WithHeartbeat(this Task primaryTask, TimeSpan heartbeatInterval, Action<CancellationToken> heartbeatAction, CancellationToken cancellationToken) {
            if (cancellationToken.IsCancellationRequested) {
                return;
            }
    
            var stopHeartbeatSource = new CancellationTokenSource();
            cancellationToken.Register(stopHeartbeatSource.Cancel);
    
            await Task.WhenAny(primaryTask, PerformHeartbeats(heartbeatInterval, heartbeatAction, stopHeartbeatSource.Token));
            stopHeartbeatSource.Cancel();
        }
            
        private static async Task PerformHeartbeats(TimeSpan interval, Action<CancellationToken> heartbeatAction, CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                await Task.Delay(interval, cancellationToken);
                if (!cancellationToken.IsCancellationRequested) {
                    heartbeatAction(cancellationToken);
                }
            }
        }
    }
