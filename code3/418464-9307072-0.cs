    Observable.Interval(TimeSpan.FromMilliseconds(200))
        .Take(9)
        .Concat(Observable.Throw<long>(new Exception("Die!")));
    Observable.Interval(TimeSpan.FromMilliseconds(200))
        .SelectMany(x => {
            if (x < 10) return Observable.Return(x);
            return Observable.Throw<long>(new Exception("Die!"));
        });
