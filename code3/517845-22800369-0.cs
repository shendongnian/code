    public Magnifier(Window window)
    {
        if (window == null)
            throw new ArgumentNullException("form");
        hwnd = new WindowInteropHelper(window).Handle;
        magnification = 2.0f;
        this.window = window;
        this.window.SizeChanged += form_Resize;
        this.window.Closing += form_FormClosing;
        timer = new DispatcherTimer();
        timer.Tick += timer_Tick;
        Loaded+=MainWindow_Loaded;
    }
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        initialized = NativeMethods.MagInitialize();
        if (initialized)
        {
            handle = new WindowInteropHelper(this).Handle;
            SetupMagnifier();
            timer.Interval = TimeSpan.FromMilliseconds(NativeMethods.USER_TIMER_MINIMUM);
            timer.Start();// = true;
        }
    }
