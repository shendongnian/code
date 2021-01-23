    interface IIntPoint : IEquatable<IntPoint>
    {
        int X { get; }
        int Y { get; }
    }
    interface IDoublePoint  // does not inherit IEquatable<DoublePoint>; see below.
    {
        double X { get; }
        double Y { get; }
    }
