    mainContainer.Children.Add(new MdiChild()
    {
        MaximizeBox = false,
        MinimizeBox = false,
        Resizable = true,
        ShowIcon = false,
        Title = "X",
        Position = new Point(500,500),
        Content = tableWindow.Content as UIElement //Opens new instance of my window class
    });
