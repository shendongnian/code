     public static class CustomForeground
    {
        public static readonly DependencyProperty CustomForegroundProperty = DependencyProperty.RegisterAttached(
                          "CustomForeground",
                          typeof(Brush),
                          typeof(CustomForeground),
                          new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender, OnChange));
        public static void SetCustomForeground(UIElement element, Brush value)
        {
            element.SetValue(CustomForegroundProperty, value);
        }
        public static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs arg)
        {
            if (arg.NewValue != null)
                d.SetValue(TextBlock.ForegroundProperty, arg.NewValue);
        }
    }
