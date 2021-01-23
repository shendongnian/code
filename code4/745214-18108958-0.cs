    public class Extensions
    {
        public static readonly DependencyProperty OverWidthProperty =
            DependencyProperty.RegisterAttached("OverWidth", typeof(double), typeof(Extensions), new PropertyMetadata(default(double)));
    
        public static void SetOverWidth(UIElement element, double value)
        {
            element.SetValue(OverWidthProperty, value);
        }
    
        public static double GetOverWidth(UIElement element)
        {
            return (double)element.GetValue(OverWidthProperty);
        }
    }
