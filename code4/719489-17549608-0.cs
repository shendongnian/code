    private static void DecoratorLoaded(object obj, RoutedEventArgs e)
    {
         var decorator = obj as Decorator;
         if (decorator != null && decorator.IsVisible)
         {
            // get the position
            Point renderedLocation = decorator.TranslatePoint(new Point(0, 0), Application.Current.MainWindow);
            if (renderedLocation != new Point(0, 0))
            {
               // check width
               var maxAllowedWidth = Application.Current.MainWindow.ActualWidth - renderedLocation.X - 40;               
               decorator.SetValue(FrameworkElement.MaxWidthProperty, maxAllowedWidth);
               // check place above the control
               var isEnoughPlaceAbove = renderedLocation.Y > decorator.ActualHeight + 10;
               decorator.SetValue(Grid.RowProperty, isEnoughPlaceAbove ? 0 : 2);
              
               // invalidate to re-render
               decorator.InvalidateVisual();               
            }
         }
    }
