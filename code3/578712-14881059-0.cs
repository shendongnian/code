    private void OnToggleText(object sender, System.Windows.Input.GestureEventArgs e)
    {
        Grid g = (Grid)sender;
        g.Children[1].Visibility = g.Children[1].Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        g.SizeChanged += g_SizeChanged;
    }
    void g_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Grid g = (Grid)sender;
        g.SizeChanged -= g_SizeChanged;
        g.SizeChanged += g_SizeChanged2;
        g.Children[1].Visibility = g.Children[1].Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
    }
    void g_SizeChanged2(object sender, SizeChangedEventArgs e)
    {
        Grid g = (Grid)sender;
        g.SizeChanged -= g_SizeChanged2;
        g.Children[1].Visibility = g.Children[1].Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
    }
