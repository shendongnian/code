    private readonly Timer _timer;
    private int _angle;
    
        public MainWindow()
        {
            InitializeComponent();
            _timer = new Timer(500);
            _timer.Elapsed += RotateWheelEvent;
            _timer.Start();
            _angle = 0;
        }
    
        public void RotateWheelEvent(object sender, EventArgs args)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
            {
                _angle += 15;
                ImageWheel.RenderTransformOrigin = new Point(0.5, 0.5);
                ImageWheel.RenderTransform = new RotateTransform(_angle);
            }); 
        }
