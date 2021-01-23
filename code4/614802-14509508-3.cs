    private static void HideItPropertyChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        (d as MySuperiorDateTimePicker).OnHideItChanged((bool)e.OldValue, 
            (bool)e.NewValue);
    }
    private void OnHideItChanged(bool oldValue, bool newValue)
    {
        if(BusyTemplate == null)
            return;
        FindTimePicker().Visibility = newValue ? Visibility.Visible : 
            Visibility.Collapsed;
    }
    private UIElement FindTimePicker()
    {
        //snip null checks
        return GetTemplateChild("PART_TimePicker") as UIElement;
    }
