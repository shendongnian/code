    public static bool GetIsHitTestTarget(DependencyObject obj) {
        return (bool)obj.GetValue(IsHitTestTargetProperty);
    }
    public static void SetIsHitTestTarget(DependencyObject obj, bool value) {
        obj.SetValue(IsHitTestTargetProperty, value);
    }
    public static readonly DependencyProperty IsHitTestTargetProperty = DependencyProperty.RegisterAttached("IsHitTestTarget", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
