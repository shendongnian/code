    public static class ExtendedProperties
    {
        public static readonly DependencyProperty IsDirtyProperty =
            DependencyProperty.RegisterAttached("IsDirty", typeof(bool), typeof(ExtendedProperties), new PropertyMetadata(default(bool)));
    
        public static void SetIsDirty(UIElement element, bool value)
        {
            element.SetValue(IsDirtyProperty, value);
        }
    
        public static bool GetIsDirty(UIElement element)
        {
            return (bool)element.GetValue(IsDirtyProperty);
        }
    }
