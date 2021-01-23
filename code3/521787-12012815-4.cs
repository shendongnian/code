    public IEnumerable<NCPoint> TransformPoints(List<NCPoint> points, int foo, int bar, int baz)
    {
        // returning an iterator over the sequence so original list won't be changed
        // and creating new NCPoint using old NCPoint + modifications so old points
        // aren't altered.
        NCPoint[] result = new NCPoint[points.Count];
        for (int i=0; i<points.Count; ++i)
        { 
            // if you have a "copy constructor", can use it here.
            result[i] = new NCPoint();
            result[i].X = points[i].X + foo;
            result[i].Y = points[i].Y + bar;
            result[i].Z = points[i].Z + baz;
        }
        return result;
    }
