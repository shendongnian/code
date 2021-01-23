    public class BindableRectangleBounds : DependencyObject
    {
        public static DependencyProperty BoundsProperty = DependencyProperty.RegisterAttached("Bounds", typeof(Rect), typeof(BindableRectangleBounds), new PropertyMetadata(new Rect(), OnBoundsChanged));
        public static void SetBounds(DependencyObject dp, Rect value)
        {
            dp.SetValue(BoundsProperty, value);
        }
        public static void GetBounds(DependencyObject dp)
        {
            dp.GetValue(BoundsProperty);
        }
        public static void OnBoundsChanged(DependencyObject dp, DependencyPropertyChangedEventArgs args)
        {
            var property = dp.GetType().GetProperty("Bounds");
            if (property != null)
            {
                property.SetValue(dp, args.NewValue, null);
            }
        }
    }
