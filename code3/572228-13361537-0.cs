    private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (canvas != null)
        {
            var drawingAttributes = canvas.DefaultDrawingAttributes;
            Double newSize = Math.Round(BrushRadiusSlider.Value, 0);
            drawingAttributes.Width = newSize;
            drawingAttributes.Height = newSize;
        }
    }
