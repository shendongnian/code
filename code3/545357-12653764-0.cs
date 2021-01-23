        static IObservable<T> DelayBetweenValues<T>(this IObservable<T> observable, TimeSpan interval, IScheduler scheduler)
        {
            return Observable.Create<T>(observer =>
            {
                var offset = TimeSpan.Zero;
                return observable
                    .TimeInterval(scheduler)
                    .Subscribe
                    (
                        ts =>
                        {
                            if (ts.Interval < interval)
                            {
                                offset = offset.Add(interval);
                                scheduler.Schedule(offset, () => observer.OnNext(ts.Value));
                            }
                            else
                            {
                                offset = TimeSpan.Zero;
                                observer.OnNext(ts.Value);
                            }
                        }
                    );
            });
        }
