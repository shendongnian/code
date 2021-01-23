    private void OnAssociatedObjectManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
    {
        _startPosition = new Point(
            Canvas.GetLeft(this.AssociatedObject),
            Canvas.GetTop(this.AssociatedObject));
    }
    
    private void OnAssociatedObjectManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs manipulationDeltaRoutedEventArgs)
    {
        var dx = manipulationDeltaRoutedEventArgs.Cumulative.Translation.X;
        var dy = manipulationDeltaRoutedEventArgs.Cumulative.Translation.Y;
    
        var x = _startPosition.X + dx;
        var y = _startPosition.Y + dy;
    
        if (manipulationDeltaRoutedEventArgs.IsInertial)
        {
            while (x < 0 ||
                   x > _canvas.ActualWidth - this.AssociatedObject.ActualWidth)
            {
                if (x < 0)
                    x = -x;
                if (x > _canvas.ActualWidth - this.AssociatedObject.ActualWidth)
                    x = 2 *
                        (_canvas.ActualWidth - this.AssociatedObject.ActualWidth) -
                        x;
            }
    
            while (y < 0 ||
                   y > _canvas.ActualHeight - this.AssociatedObject.ActualHeight)
            {
                if (y < 0)
                    y = -y;
                if (y > _canvas.ActualHeight - this.AssociatedObject.ActualHeight)
                    y = 2 * (_canvas.ActualHeight - this.AssociatedObject.ActualHeight) -
                        y;
            }
        }
        else
        {
            if (x < 0)
                x = 0;
            if (x > _canvas.ActualWidth - this.AssociatedObject.ActualWidth)
                x = _canvas.ActualWidth - this.AssociatedObject.ActualWidth;
            if (y < 0)
                y = 0;
            if (y > _canvas.ActualHeight - this.AssociatedObject.ActualHeight)
                y = _canvas.ActualHeight - this.AssociatedObject.ActualHeight;
        }
    
        Canvas.SetLeft(this.AssociatedObject, x);
        Canvas.SetTop(this.AssociatedObject, y);
    }
