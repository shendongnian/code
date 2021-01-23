    public class MainWindow : Window
    {
       DispatcherTimer MyTimer;
       public MainWindow()
       {
          InitializeComponent();
          MyTimer = new System.Windows.Threading.DispatcherTimer();
          MyTimer.Interval = new TimeSpan(0, 0, 0, 0, 30000);
          MyTimer.Tick += new EventHandler(refreshData);
          // Start the timer
          MyTimer.Start();
       }
       public void OnWindowClosing(object sender, CancelEventArgs e) 
       {
           // stop the timer
           MyTimer.Stop();
       }
       public void refreshData(object sender, EventArgs e)
       {
          Conection c = new Conection();
          c.sayHello();
       }
    }
