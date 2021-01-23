    internal class DependencyPropertyClass
    {
        public static readonly DependencyProperty IsPaneVisibleProperty =
            DependencyProperty.RegisterAttached("IsPaneVisible", typeof(bool), typeof(DependencyPropertyClass),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsPaneVisible_PropertyChanged));
        private static void IsPaneVisible_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        public static bool GetIsPaneVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPaneVisibleProperty);
        }
        public static void SetIsPaneVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPaneVisibleProperty, value);
        }
    }
