    private void ContextMenu_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var isVisible = (bool)e.NewValue;
        if (isVisible)
        {
            //...
        }
    }
