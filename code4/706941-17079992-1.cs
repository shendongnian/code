    public MainPage()
    {
        DataContext = new MainViewModel();
        InitializeComponent();
    }
    
    private void AddButtonClick(object sender, EventArgs e)
    {
        TimeSpan time = // get time
        ((MainViewModel)DataContext).LapTimes.Add(time);
    }
