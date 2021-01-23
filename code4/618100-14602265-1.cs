    object sync = new object();
    double sum1 = 0.0;
    double sum2 = 0.0;
    Parallel.For<Tuple<double, double>>(2, 10,
        () => { return new Tuple<double, int>(0.0, 0.0); },
        (i, pls, state) =>
        {
            double result = function1(i);
            state = new Tuple<double, double>( state.Item1 + result, state.Item2 + function2(result))
            return state;
        },
        state => { lock (sync) { sum1 += state.Item1; sum2 += state.Item2; } }
    );
