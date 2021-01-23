    public static class DrawingContextExtensions
    {
        public static void DrawLine(this DrawingContext drawingContext,
            Pen background, Pen foreground, Point start, Point end)
        {
            drawingContext.DrawLine(background, start, end);
            drawingContext.DrawLine(foreground, start, end);
        }
    }
