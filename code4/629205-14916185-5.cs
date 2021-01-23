    // get angle (in Radians) from p0 to p1
    public static double AngleBetween(Point2D p0, Point2D p1)
    {
        return Math.Atan2(p1.X - p0.X, p1.Y - p0.Y);
    }
