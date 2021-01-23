    private void SetMask(double radius)
    {
        var maskGeometry = new EllipseGeometry(CenterPos, radius, radius);
        var maskDrawing = new GeometryDrawing(Brushes.Black, null, maskGeometry);
        var maskBrush = new DrawingBrush
        {
            Drawing = maskDrawing,
            Stretch = Stretch.None,
            ViewboxUnits = BrushMappingMode.Absolute,
            AlignmentX = AlignmentX.Left,
            AlignmentY = AlignmentY.Top
        };
        Img.OpacityMask = maskBrush;
    }
