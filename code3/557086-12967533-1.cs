    var child = new MdiChild
    {
        MaximizeBox = false,
        MinimizeBox = false,
        Resizable = true,
        ShowIcon = false,
        Title = "X",
        Content = tableWindow.Content as UIElement //Opens new instance of my window class
    };
    mainContainer.Children.Add(child);
    child.Position = new Point(500, 500);
    //      or
    //child.Margin = new Thickness(500, 500, 0, 0);
