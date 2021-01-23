    public class Underlying
    {
        public IObservable<bool> GetDeferredObservable(object connection)
        {
            return Observable.DeferAsync<bool>(token => {
                return Task.Factory.StartNew(() => {
                    Console.WriteLine("UNDERLYING ENGAGED");
                    Thread.Sleep(1000);
                    // Let's pretend there's some static on the line...
                    return Observable.Return(true)
                        .Concat(Observable.Return(false))
                        .Concat(Observable.Return(true));
                }, token);
            });
        }
    }
