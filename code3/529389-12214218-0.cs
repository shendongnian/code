      DispatcherTimer timer;
    
      public Window1()
            {
                InitializeComponent();
                ComponentDispatcher.ThreadIdle += new EventHandler(ComponentDispatcher_ThreadIdle);
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(30);
                timer.Tick += new EventHandler(timer_Tick);
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                //Do your action here
                timer.Stop();
            }
    
            void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
            {
                timer.Start();
            }
