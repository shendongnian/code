    public static class ShapeExtensions
    {
        public static void Draw(this Rectangle r, Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), r);
        }
    }
