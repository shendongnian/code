    public static IEnumerable<PointF> GetCardinalIntersections(
        this PointF point,
        IEnumerable<PointF> others);
    {
        return others.SelectMany((o) => point.GetCardinalIntersections(o));
    }
