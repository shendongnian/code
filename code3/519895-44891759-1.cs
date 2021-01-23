    public static class RelativeFontSize
    {
        public static readonly DependencyProperty RelativeFontSizeProperty =
            DependencyProperty.RegisterAttached("RelativeFontSize", typeof(Double), typeof(RelativeFontSize), new PropertyMetadata(1.0, HandlePropertyChanged));
        public static Double GetRelativeFontSize(Control target)
            => (Double)target.GetValue(RelativeFontSizeProperty);
        public static void SetRelativeFontSize(Control target, Double value)
            => target.SetValue(RelativeFontSizeProperty, value);
        static Boolean isInTrickery = false;
        public static void HandlePropertyChanged(Object target, DependencyPropertyChangedEventArgs args)
        {
            if (isInTrickery) return;
            if (target is Control control)
            {
                isInTrickery = true;
                try
                {
                    control.SetValue(Control.FontSizeProperty, DependencyProperty.UnsetValue);
                    var unchangedFontSize = control.FontSize;
                    var value = (Double)args.NewValue;
                    control.FontSize = unchangedFontSize * value;
                    control.SetValue(Control.FontSizeProperty, unchangedFontSize * value);
                }
                finally
                {
                    isInTrickery = false;
                }
            }
        }
    }
