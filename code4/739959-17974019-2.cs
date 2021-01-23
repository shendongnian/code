    public static IObservable<TIn> SampleWithRepetition<TIn, TPulse>(this IObservable<TIn> source, IObservable<TPulse> pulse)
    {
        return Observable.Create<TIn>(obs =>
            {
                var gate = new object();
                var x = new {Value = default(TIn), HasValue = false};
                return new CompositeDisposable()
                    {
                        source.Subscribe(
                            y =>
                                {
                                    lock (gate)
                                        x = new {Value = y, HasValue = true};
                                },
                            obs.OnError,
                            obs.OnCompleted),
                        pulse.Subscribe(
                            _ =>
                                {
                                    bool hasValue = false;
                                    TIn value = default(TIn);
                                    lock (gate)
                                    {
                                        hasValue = x.HasValue;
                                        value = x.Value;
                                    }
                                    if (hasValue)
                                        obs.OnNext(value);
                                },
                            obs.OnError,
                            obs.OnCompleted)
                    };
            });
    }
}
