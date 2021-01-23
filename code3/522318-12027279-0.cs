        public static CancellationTokenSource Poll(
            Func<bool> termination,
            Action<CancellationToken> onexit,
            int waitTime = 0,
            int pollInterval = 1000)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Action dispose = cts.Cancel;
            var timer = new Timer(_ =>
            {
                if (termination() || token.IsCancellationRequested)
                {
                    onexit(token);
                    dispose();
                }
            }, null, waitTime, pollInterval);
            dispose = timer.Dispose;
            return cts;
        }
