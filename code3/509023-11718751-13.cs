    public static IEnumerable<PointF> GetCardinalIntersections(
        this PointF point,
        PointF other);
    {
        return point.GetCardianls().SelectMany(other.GetCardinals(), Intersection)
            .Where(i => !i.IsEmpty());
    }
