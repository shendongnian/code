                var disposable =
                Observable.Interval(TimeSpan.FromSeconds(2))
                          .Do(Console.WriteLine)
                          .DeferDisconnection(TimeSpan.FromSeconds(5))
                          .Subscribe();
                Console.ReadLine();
                disposable.Dispose();
                Console.ReadLine();
