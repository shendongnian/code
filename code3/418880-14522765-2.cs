    interface IIntPoint : IEquatable<IIntPoint>
    {
        int X { get; }
        int Y { get; }
    }
    interface IDoublePoint  // does not inherit IEquatable<IDoublePoint>; see below.
    {
        double X { get; }
        double Y { get; }
    }
