    public static int Distance(Point p1, Point p2)
    {
        int dx = p1.X - p2.X;
        int dy = p1.Y - p2.Y;
        double distance = Math.Sqrt(dx*dx + dy*dy);
        return (int) Math.Round(distance, MidpointRounding.AwayFromZero);
    }
