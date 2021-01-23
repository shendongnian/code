    private void button1_Click(object sender, RoutedEventArgs e)
        {
            EllipseGeometry MaskGeometry = new EllipseGeometry(CenterPos, _RadiusX, _RadiusY);
            GeometryDrawing MaskDrawing = new GeometryDrawing(Brushes.Black, null, MaskGeometry);
            DrawingBrush MaskBrush = new DrawingBrush(MaskDrawing);
            MaskBrush.Stretch = Stretch.None;
            MaskBrush.ViewportUnits = BrushMappingMode.Absolute;
            MaskBrush.Viewport = MaskGeometry.Bounds;
            Img.OpacityMask = MaskBrush;  //Img is the Image control
            
        }
