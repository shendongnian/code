       DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(.1)};
       // Constructor
       public MainPage()
       {
           InitializeComponent();
           this.timer.Tick+=new EventHandler(timer_Tick);
       }
       private void timer_Tick(object sender, EventArgs e)
       {
           output.Text = DateTime.Now.ToLongTimeString();
       }
