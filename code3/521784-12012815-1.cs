    public IEnumerable<NCPoint> TransformPoints(List<NCPoint> points, int foo, int bar, int baz)
    {
        // returning an iterator over the sequence so original list won't be changed
        // and creating new NCPoint using old NCPoint + modifications so old points
        // aren't altered.
        return points.Select(p => new NCPoint
            { 
               X = p.X + foo,
               Y = p.Y + bar,
               Z = p.Z + baz
            });
    }
