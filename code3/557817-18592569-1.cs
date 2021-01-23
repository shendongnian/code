    public static void OnTopPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        UIElement panel= VisualTreeHelper.GetParent(source) as UIElement;
        if(panel != null)       
            panel.InvalidateArrange();
    }
