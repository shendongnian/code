    public class CenterOnPoint
    {
      public static readonly DependencyProperty CenterPointProperty =
         DependencyProperty.RegisterAttached("CenterPoint", typeof (Point), typeof (CenterOnPoint),
         new PropertyMetadata(default(Point), OnPointChanged));
      public static void SetCenterPoint(UIElement element, Point value)
      {
         element.SetValue(CenterPointProperty, value);
      }
      public static Point GetCenterPoint(UIElement element)
      {
         return (Point) element.GetValue(CenterPointProperty);
      }
      private static void OnPointChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         var element = (FrameworkElement)d;
         element.SizeChanged -= OnSizeChanged;
         element.SizeChanged += OnSizeChanged;
         var newPoint = (Point)e.NewValue;
         element.SetValue(Canvas.LeftProperty, newPoint.X - (element.ActualWidth / 2));
         element.SetValue(Canvas.TopProperty, newPoint.Y - (element.ActualHeight / 2));
      }
      private static void OnSizeChanged(object sender, SizeChangedEventArgs e)
      {
         var element = (FrameworkElement) sender;
         var newPoint = GetCenterPoint(element);
         element.SetValue(Canvas.LeftProperty, newPoint.X - (e.NewSize.Width / 2));
         element.SetValue(Canvas.TopProperty, newPoint.Y - (e.NewSize.Height / 2));
      }
    }
