        protected override Size ArrangeOverride(Size finalSize)
    {
        selectedLine = AdornedElement as Line;
        double left = Math.Min(selectedLine.X1, selectedLine.X2);
        double top = Math.Min(selectedLine.Y1, selectedLine.Y2);
        var startRect = new Rect(selectedLine.X1 - (startThumb.Width / 2), selectedLine.Y1 - (startThumb.Width / 2), startThumb.Width, startThumb.Height);
        startThumb.Arrange(startRect);
        var endRect = new Rect(selectedLine.X2 - (endThumb.Width / 2), selectedLine.Y2 - (endThumb.Height / 2), endThumb.Width, endThumb.Height);
        endThumb.Arrange(endRect);
        return finalSize;
    }
