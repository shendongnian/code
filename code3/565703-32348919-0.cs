    static class ExtensionMethods
    {
        public static Point Add(this Point original, Point value)
        {
            return new Point(original.X + value.X, original.Y + value.Y);
        }
        public static Point Subtract(this Point original, Point value)
        {
            return new Point(original.X - value.X, original.Y - value.Y);
        }
    }
