    public static class VectorExt
    {
    
        public static Point ToPoint(this Vector2 v)
        {
            return new Point( (int)v.X, (int)v.Y );
        }
    }
