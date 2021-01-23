    private static void FocusedExChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var toolBar = d as ToolBar;
        if (toolBar != null && (bool)e.NewValue)
        {
            toolBar.Focus();
        }
    }
