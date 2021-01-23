    public static IObservable<Message> ObservableStream(int id)
    {
        return Observable.Create<Message>(async (observer, token) =>
        {
             // no exception handling required.  If this method throws,
             // Rx will catch it and call observer.OnError() for us.
             using (var stream = /*...open your stream...*/)
             {
                 string msg;
                 while ((msg = await stream.ReadLineAsync()) != null)
                 {
                     if (token.IsCancellationRequested) { return; }
                     observer.OnNext(msg);
                 }
                 observer.OnCompleted();
             }
        });
    }
