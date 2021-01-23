    var g = ButtonDetails.Content as Grid;
    if (g != null)
    {
        var names = g.Children.OfType<FrameworkElement>().Select(x => x.Name);
        // do something
    }
    else
        // do something with ButtonDetails.Name
