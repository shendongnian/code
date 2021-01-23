    public MainPage()
    {
        InitializeComponent();
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromHours(1) };
        timer.Tick += new EventHandler(timer_Tick);
        SetImageSource();
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        SetImageSource();
    }
    void SetImageSource()
    {
        int hour = DateTime.Now.Hour;
        if (hour % 10 == 0)
            imag1.Source = new BitmapImage(new Uri("img/knapTaand.png", UriKind.Relative));
        else
            imag1.Source = new BitmapImage(new Uri("img/knapSluk.png", UriKind.Relative));
    }
