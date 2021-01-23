    sealed class DoublePointNearEqualityComparerByTolerance : IEqualityComparer<IDoublePoint>
    {
        public DoublePointNearEqualityComparerByTolerance(double tolerance) { … }
        …
        public bool Equals(IDoublePoint a, IDoublePoint b)
        {
            return Math.Abs(a.X - b.X) <= tolerance  &&  Math.Abs(a.Y - b.Y) <= tolerance;
        }
        …
    }
