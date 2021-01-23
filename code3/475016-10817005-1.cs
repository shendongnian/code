    private void ExpanderGotFocus(object sender, RoutedEventArgs e)
    {
        var expander = (Expander) sender;
        if (!expander.IsExpanded )
        {
            expander.IsExpanded = true;
        }
    }
    private void ControlIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        Keyboard.Focus((IInputElement)sender);
    }
         
