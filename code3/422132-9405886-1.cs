            var taskCount = 10;
            var cancellationTokenSource = new CancellationTokenSource();
            for (int i = 0; i < taskCount ; i++)
            {
                var cancellationToken = cancellationTokenSource.Token;
                Task.Factory.StartNew(() =>
                {
                    // do work here.
                    // Also periodically check 
                    if( cancellationToken.IsCancellationRequested )
                        return;
                    // or wait on wait handle
                    cancellationToken.WaitHandle.WaitOne(timeout);
                }, cancellationToken);
            }
            // to cancel all threads 
            cancellationTokenSource.Cancel();
