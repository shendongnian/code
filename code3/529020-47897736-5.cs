    public VisualLineDrawingVisual(VisualLine visualLine, double lineSpacing) {
        this.VisualLine = visualLine;
        var drawingContext = RenderOpen();
        double pos = 0;
        foreach (TextLine textLine in visualLine.TextLines) {
            textLine.Draw(drawingContext, new Point(0, pos), InvertAxes.None);
            pos += textLine.Height * lineSpacing;
        }
        this.Height = pos;
        drawingContext.Close();
    }
