    Observable.Create<MyPoco>(
        observer =>
        {
            var distinctPocos = new BehaviorSubject<IObservable<MyPoco>>(pocos.Distinct(x => x.Id));
            var timerSubscription =
                Observable.Timer(
                    new DateTimeOffset(DateTime.UtcNow.Date.AddDays(1)),
                    TimeSpan.FromDays(1),
                    schedulerService.Default).Subscribe(
                        t =>
                        {
                            Log.Info("Daily reset - resetting distinct subscription.");
                            distinctPocos.OnNext(pocos.Distinct(x => x.Id));
                        });
            var pocoSubscription = distinctPocos.Switch().Subscribe(observer);
            return new CompositeDisposable(timerSubscription, pocoSubscription);
        });
