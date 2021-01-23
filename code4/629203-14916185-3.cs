    // Generate all control points for a set of knots
    public static List<Point2D> GenerateControlPoints(List<Point2D> knots)
    {
        if (knots == null || knots.Count < 3)
            return null;
        List<Point2D> res = new List<Point2D>();
        // First control point is same as first knot
        res.Add(knots.First());
        // generate control point pairs for each non-end knot 
        for (int i = 1; i < knots.Count - 1; ++i)
        {
            Point2D[] cps = GetControlsPoints(knots[i - 1], knots[i], knots[i+1]);
            res.AddRange(cps);
        }
        // Last control points is same as last knot
        res.Add(knots.Last());
        return res;
    }
