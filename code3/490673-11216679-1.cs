    var disposable =
                Observable.Interval(TimeSpan.FromSeconds(2))
                          .ClosingSubscribe(TimeSpan.FromSeconds(5))
                          .Subscribe(Console.WriteLine);
                Console.ReadLine();
                disposable.Dispose();
                Console.ReadLine();
