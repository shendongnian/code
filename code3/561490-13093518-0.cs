    public static Canvas SetCoordinateSystem(this Canvas canvas, Double xMin, Double xMax, Double yMin, Double yMax)
    {
        var width = xMax - xMin;
        var height = yMax - yMin;
    
        var translateX = width / 2.0;
        var translateY = height / 2.0;
    
        var group = new TransformGroup();
    
        group.Children.Add(new TranslateTransform(translateX, -translateY));
        group.Children.Add(new ScaleTransform(canvas.ActualWidth / width, canvas.ActualHeight / -height));
    
        canvas.RenderTransform = group;
    
        return canvas;
    }
