    public IEnumerable<double> logspace(double start, double end, int count)
    {
        double d = (double)count, p = end/start;
        return Enumerable.Range(0, count).Select(i => start * Math.Pow(p, i/d));
    }
    logspace(0.1, 1, 10); // 0.1, 0.13, 0.16, 0.2, 0.25, 0.32, 0.4, 0.5, 0.63, 0.79
