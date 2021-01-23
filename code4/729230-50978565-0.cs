    public class CornerRadiusSetter
    {
        public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached(nameof(Border.CornerRadius), typeof(CornerRadius),
                typeof(CornerRadiusSetter), new UIPropertyMetadata(new CornerRadius(), CornerRadiusChangedCallback));
        public static void CornerRadiusChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;
            control.Loaded += new RoutedEventHandler(Control_Loaded);
        }
        private static void Control_Loaded(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            if (control == null || control.Template == null) return;
            control.ApplyTemplate();
            Border border = control.Template.FindName("border", control) as Border;
            if (border == null) return;
            border.CornerRadius = GetCornerRadius(control);
        }
    }
