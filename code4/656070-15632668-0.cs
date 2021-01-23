    public static void SetIsVisibleWhenReadOnly(UIElement element, bool value)
    {
        element.SetValue(IsVisibleWhenReadOnlyProperty, value);
    }
    public static bool GetIsVisibleWhenReadOnly(UIElement element)
    {
        return (bool)element.GetValue(IsVisibleWhenReadOnlyProperty);
    }
    // Using a Registerd DependencyProperty as the backing store for IsVisibleWhenReadOnly.
    public static readonly DependencyProperty IsVisibleWhenReadOnlyProperty =
            DependencyProperty.RegisterAttached("IsVisibleWhenReadOnly",
                                         typeof(bool),
                                         typeof(Button),
                                         new PropertyMetadata(true));
