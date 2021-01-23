    var appBar = new AppBar();
    var stackPanel = new StackPanel{Orientation = Orientation.Horizontal};
    
    stackPanel.Children.Add(new Button { Content = "Button1" });
    stackPanel.Children.Add(new Button { Content = "Button2" });
    
    var buttonWithStyle = new Button();
    buttonWithStyle.Style = Application.Current.Resources["EditAppBarButtonStyle"] as Style;
    stackPanel.Children.Add(buttonWithStyle);
    appBar.Content = stackPanel;
    
    this.TopAppBar = appBar;
