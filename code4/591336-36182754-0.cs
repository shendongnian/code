                var cancellationTokenSource = new CancellationTokenSource();
                basicTask = Task.Factory.StartNew(() =>
                {
                    for (;;)
                    {
                        var z = DateTime.Today.ToString();
                    }
                }, cancellationTokenSource.Token);
                var basicTask2 = Task.Factory.StartNew(() =>
                {
                    for (;;)
                    {
                        var z = DateTime.Today.ToString();
                    }
                }, cancellationTokenSource.Token);
                //var usingThisCodeWillResultInADeadlock = cancellationTokenSource.Token.Register(() => { });
                //usingThisCodeWillResultInADeadlock.Dispose();
                cancellationTokenSource.Cancel();
                basicTask.Wait();
