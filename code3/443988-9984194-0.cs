    DoubleAnimation widthAnimation = new DoubleAnimation
    {
        From = 0,
        To = 10,
        Duration = TimeSpan.FromSeconds(5)
    };
    DoubleAnimation heightAnimation = new DoubleAnimation
    {
        From = 0,
        To = 10,
        Duration = TimeSpan.FromSeconds(5)
    };
    Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Ellipse.WidthProperty));
    Storyboard.SetTarget(widthAnimation, e);
    Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Ellipse.HeightProperty));
    Storyboard.SetTarget(heightAnimation, e);
    Storyboard s = new Storyboard();
    s.Children.Add(widthAnimation);
    s.Children.Add(heightAnimation);
    s.Begin();
