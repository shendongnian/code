    var number = _rng.Value.NextDouble() * 100;
    // ...
    private static int _staticSeed = Environment.TickCount;
    private static readonly ThreadLocal<Random> _rng = new ThreadLocal<Random>(() =>
        {
            int seed = Interlocked.Increment(ref _staticSeed) & 0x7FFFFFFF;
            return new Random(seed);
        });
