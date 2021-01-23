    // Calculate control points for Point 'p1' using neighbour points
    public static Point2D[] GetControlsPoints(Point2D p0, Point2D p1, Point2D p2, double tension = 0.5)
    {
        // get length of lines [p0-p1] and [p1-p2]
        double d01 = Distance(p0, p1);
        double d12 = Distance(p1, p2);
        // calculate scaling factors as fractions of total
        double sa = tension * d01 / (d01 + d12);
        double sb = tension * d12 / (d01 + d12);
        // left control point
        double c1x = p1.X - sa * (p2.X - p0.X);
        double c1y = p1.Y - sa * (p2.Y - p0.Y);
        // right control point
        double c2x = p1.X + sb * (p2.X - p0.X);
        double c2y = p1.Y + sb * (p2.Y - p0.Y);
        // return control points
        return new Point2D[] { new Point2D(c1x, c1y), new Point2D(c2x, c2y) };
    }
