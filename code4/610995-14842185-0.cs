        public static IConnectableObservable<Command> GetReadObservable(this CommandReader reader)
        {
           return Observable.Create<Command>(async (subject, token) =>
            {
                try
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            subject.OnCompleted();
                            return;
                        }
                        Command cmd = await reader.ReadCommandAsync();
                        subject.OnNext(cmd);
                        
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        subject.OnError(ex);
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("An exception was thrown while trying to call OnError on the observable subject -- means you're not catching exceptions everywhere");
                        throw;
                    }
                }
            }).Publish();
        }
