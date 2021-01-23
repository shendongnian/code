    myAppBar = new AppBar();
    StackPanel sp = new StackPanel();
    sp.Orientation = Orientation.Horizontal;
    Button myButton = new Button();
    myButton.Content = "Click Me";
    sp.Children.Add(myButton);
    myAppBar.Content = sp;
