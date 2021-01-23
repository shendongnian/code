    public partial class MainWindow : Window
    {            
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();                            
          
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();                                
         }
    
         private void dispatcherTimer_Tick(object sender, EventArgs e)
         {
            Window1 w = new Window1();
            this.Hide();
            w.Show();
            dispatcherTimer.Stop();               
         }
    }
