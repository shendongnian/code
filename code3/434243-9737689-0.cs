    public MainPage()
    {
        InitializeComponent();
    
        this.BackKeyPress += new EventHandler<System.ComponentModel.CancelEventArgs>(MainPage_BackKeyPress);
    }
    
    void MainPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    
        Dispatcher.BeginInvoke(() =>
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        });
    }
