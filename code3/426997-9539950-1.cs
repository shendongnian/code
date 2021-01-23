    namespace TimerTest
    {
        public partial class MainWindow : Window
        {
            private delegate void updateDelegate(string text);
            private void updateTextBox(string text)
            {
                textBox1.Text += text;
            }
            //Declaring my aTimer as global
            public static System.Timers.Timer aTimer;
            //Function that is called
            public void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                 textBox1.Dispatcher.BeginInvoke(
                       new updateDelegate(updateTextBox), "SomeText ");
            }
            public MainWindow()
            {
                InitializeComponent();
                aTimer = new Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 1000; // every 5 seconds
                aTimer.Enabled = true;
            }
        }
    }
