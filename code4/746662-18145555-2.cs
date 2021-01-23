    private void Container_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var container = (UIElement)sender;
        var hitElement = container.InputHitTest(e.GetPosition(container));
        Trace.TraceInformation("Hit Element: {0}", hitElement);
    }
