    private static IObservable<long> GetObservable(IScheduler scheduler)
    {
      return Observable.Create<long>(obs =>
      {
        var disposables = new CompositeDisposable();
        disposables.Add(
          Disposable.Create(() =>
          {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Log("Disposing is really done now!");
          }));
        disposables.Add(
          scheduler.Schedule(() =>
          {
            Log("Subscribing starting.. this will take a few seconds..");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            disposables.Add(
              Observable.Interval(TimeSpan.FromSeconds(1)).Do(_ => Log("I am polling...")).Subscribe(obs));
          }));
        return disposables;
      });
    private static void Main(string[] args)
    {
      var foo = GetObservable(NewThreadScheduler.Default);
      Log("I am subscribing..");
      var disp = foo.Subscribe(i => Log("Processing " + i.ToString()));
      Log("I have returned from subscribing...");
      // SC.Current is null in a ConsoleApp :/  Can I get a SC that uses my current thread?
      //var dispSynced = new ContextDisposable(SynchronizationContext.Current, disp);
      Thread.Sleep(TimeSpan.FromSeconds(5));
      Log("I'm going to dispose...");
      //dispSynced.Dispose();
      disp.Dispose();
      Log("Disposed has returned...");
      Console.ReadKey();
    }
