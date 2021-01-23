    public static void RemoveChild(Canvas canvas, Point position)
    {
        var element = canvas.InputHitTest(position) as UIElement;
        UIElement parent;
        while (element != null &&
            (parent = VisualTreeHelper.GetParent(element) as UIElement) != canvas)
        {
            element = parent;
        }
        if (element != null)
        {
            canvas.Children.Remove(element);
        }
    }
