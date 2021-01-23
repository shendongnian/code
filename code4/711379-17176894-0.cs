    var wax = new DoubleAnimation { Duration = TimeSpan.FromSeconds(1) };
    var way = new DoubleAnimation { Duration = TimeSpan.FromSeconds(1) };
    wax.To = ...
    way.To = ...
    Storyboard.SetTargetProperty(wax,
                                 new PropertyPath("RenderTransform.Children[0].ScaleX"));
    Storyboard.SetTargetProperty(way,
                                 new PropertyPath("RenderTransform.Children[0].ScaleY"));
    Storyboard.SetTarget(wax, Wedge1);
    Storyboard.SetTarget(way, Wedge1);
    var sb = new Storyboard();
    sb.Children.Add(wax);
    sb.Children.Add(way);
    sb.Begin();
