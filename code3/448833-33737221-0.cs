    IObservable<string> ObserveStringStream(Stream inputStream)
    {
        return Observable.Using(() => new StreamReader(inputStream), 
            sr => Observable.Create<string>(async (obs, ct) =>
            {
                while (true)
                {
                    ct.ThrowIfCancellationRequested();
                    var line = await sr.ReadLineAsync().ConfigureAwait(false);
                    if (line == null)
                        break;
                    obs.OnNext(line);
                }
                obs.OnCompleted();
        }));
    }
