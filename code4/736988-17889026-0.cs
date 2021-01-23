     public static Point Vector2ToPoint(Vector2 vector2)
        {
            Point pt = new Point(
                (int)(vector2.X + 0.5f), (int)(vector2.Y + 0.5f));
            return pt;
        }
