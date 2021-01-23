    var appBar = new AppBar();
    var stackPanel = new StackPanel{Orientation = Orientation.Horizontal};
    
    stackPanel.Children.Add(new Button { Content = "Button1" });
    stackPanel.Children.Add(new Button { Content = "Button2" });
    
    appBar.Content = stackPanel;
    
    this.TopAppBar = appBar;
