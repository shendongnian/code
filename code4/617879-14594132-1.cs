            private System.Threading.Timer _timer;
            private int _angle;
    
            public MainWindow()
            {
                InitializeComponent();
                  _timer = new System.Threading.Timer((o) => 
                  {
                      _angle += 15;
                      Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
                      {
                          ImageWheel.RenderTransformOrigin = new Point(0.5, 0.5);
                          ImageWheel.RenderTransform = new RotateTransform(_angle);
                      }); 
                  }, null, 500, 500);
            }
