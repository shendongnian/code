    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        InitializeComponent();
    
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, 
            new Action(delegate() { MessageBox.Show("MyMessage"); }));
    }
