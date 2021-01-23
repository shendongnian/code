        private static void Main(string[] args)
        {
            var foo = Observable.CreateWithDisposable<long>(obs =>
            {
                Log("Subscribing starting.. this will take a few seconds..");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var sub = Observable.Interval(TimeSpan.FromSeconds(1))
                                .Do(_ => Log("I am polling..."))
                                .Subscribe(obs);
                return Disposable.Create(
                    () =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            sub.Dispose();
                            Log("Disposing is really done now!");
                        });                    
            });
            Log("I am subscribing..");
            var disp = foo.SubscribeOn(Scheduler.NewThread).Subscribe(i => Log("Processing " + i.ToString()));
            Log("I have returned from subscribing...");
            var dispSynced = new ContextDisposable(new ConsoleAppSynchronizationContext(), disp);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Log("I'm going to dispose...");
            dispSynced.Dispose();
            disp.Dispose();
            Log("Disposed has returned...");
            Console.ReadKey();
        }
        
