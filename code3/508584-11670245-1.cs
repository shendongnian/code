     public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }
    
        void dt_Tick(object sender, EventArgs e)
        {
            if (pressed == true)
            {
                Point c = Mouse.GetPosition(canvas1);
                Point c1 = Mouse.GetPosition(Rectangle);
    
                Canvas.SetLeft(Rectangle, c.X - c1.X);
                Canvas.SetTop(Rectangle, c.Y - c1.Y);
            }
        }
        bool pressed = false;
        private void rectangle1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pressed = true;
        }
    
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pressed = false;
        }
