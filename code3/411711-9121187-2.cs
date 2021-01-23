    MainWindow() {
        InitializeComponents();
    
        this.Loaded += new RoutedEventHandler(
          delegate(object sender, RoutedEventArgs args) {
            Width = 300;
            Left = SystemParameters.VirtualScreenLeft;
            Height = SystemParameters.VirtualScreenHeight;
        }
    }
