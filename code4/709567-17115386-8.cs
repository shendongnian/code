        /// <summary>
        /// Awaits a fresh Task created by the <paramref name="heartbeatTaskFactory"/> once every <paramref name="heartbeatInterval"/> while <paramref name="primaryTask"/> is running.
        /// </summary>
        public static async Task WithHeartbeat(this Task primaryTask, TimeSpan heartbeatInterval, Func<CancellationToken, Task> heartbeatTaskFactory, CancellationToken cancellationToken) {
            if (cancellationToken.IsCancellationRequested) {
                return;
            }
            var stopHeartbeatSource = new CancellationTokenSource();
            cancellationToken.Register(stopHeartbeatSource.Cancel);
            await Task.WhenAll(primaryTask, PerformHeartbeats(heartbeatInterval, heartbeatTaskFactory, stopHeartbeatSource.Token));
            if (!stopHeartbeatSource.IsCancellationRequested) {
                stopHeartbeatSource.Cancel();
            }
        }
        public static Task WithHeartbeat(this Task primaryTask, TimeSpan heartbeatInterval, Func<CancellationToken, Task> heartbeatTaskFactory) {
            return WithHeartbeat(primaryTask, heartbeatInterval, heartbeatTaskFactory, CancellationToken.None);
        }
        private static async Task PerformHeartbeats(TimeSpan interval, Func<CancellationToken, Task> heartbeatTaskFactory, CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    await Task.Delay(interval, cancellationToken);
                    if (!cancellationToken.IsCancellationRequested) {
                        await heartbeatTaskFactory(cancellationToken);
                    }
                }
                catch (TaskCanceledException tce) {
                    if (tce.CancellationToken == cancellationToken) {
                        // Totally expected
                        break;
                    }
                    throw;
                }
            }
        }
