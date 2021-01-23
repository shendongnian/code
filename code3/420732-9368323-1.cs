    private DispatcherTimer timer = new DispatcherTimer(); // timer object
    private Vector speed = new Vector(0, 0); // movement in pixels/second, initially zero
    public MainWindow()
    {
        InitializeComponent();
        timer.Interval = TimeSpan.FromMilliseconds(50); // update 20 times/second
        timer.Tick += TimerTick;
        timer.Start();
    }
    private void TimerTick(object sender, EventArgs e)
    {
        // movement in one interval
        double dx = speed.X * timer.Interval.TotalSeconds;
        double dy = speed.Y * timer.Interval.TotalSeconds;
        // update position
        Canvas.SetLeft(el, Canvas.GetLeft(el) + dx);
        Canvas.SetTop(el, Canvas.GetTop(el) + dy);
    }
