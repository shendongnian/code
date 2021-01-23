    private void AttachEvents()
    {
        Application.Current.RootVisual.MouseMove += new MouseEventHandler(RootVisual_MouseMove);
        Application.Current.RootVisual.KeyDown += new KeyEventHandler(RootVisual_KeyDown);
        Application.Current.RootVisual.AddHandler(UIElement.MouseLeftButtonDownEvent, (MouseButtonEventHandler)RootVisual_MouseButtonDown, true);
        Application.Current.RootVisual.AddHandler(UIElement.MouseRightButtonDownEvent, (MouseButtonEventHandler)RootVisual_MouseButtonDown, true);
    }
