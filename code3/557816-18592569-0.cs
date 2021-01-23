    public static void OnTopPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        UIElement element = (UIElement)source;
        // This doesn't cause ArrangeOverride below to be called
        element.InvalidateArrange();
    }
