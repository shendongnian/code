    protected override void OnDraw(DrawingContext drawingContext,
                                   StylusPointCollection stylusPoints,
                                   Geometry geometry, Brush fillBrush)
    {
        drawingContext.DrawLine(pen, firstPoint, stylusPoints.First().ToPoint());
    firstPoint = new Point(rawStylusInput.GetStylusPoints().First().ToPoint().X, rawStylusInput.GetStylusPoints().First().ToPoint().Y);
    }
