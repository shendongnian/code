    public override void DrawRect (RectangleF dirtyRect)
    {
        var context = NSGraphicsContext.CurrentContext.GraphicsPort;
        context.SetStrokeColor (new CGColor(1.0f, 0f, 0f)); // red
        context.SetLineWidth (1.0F);
        context.StrokeEllipseInRect (new RectangleF(5, 5, 10, 10));
        context.SetTextDrawingMode(CGTextDrawingMode.Stroke);
        context.TextPosition = new PointF(0f, 0f);
        context.SelectFont ("Arial", 5, CGTextEncoding.MacRoman);
        context.ShowText("My text");
    }
