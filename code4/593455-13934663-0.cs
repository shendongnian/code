    public partial class MainWindow : Window
    {
        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            Loaded+=OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            for (int i = 0; i < 200; i++)
            {
                AddLine(counter++ + ": Initial data");
            }
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += TimerOnTick;
            timer.IsEnabled = true;
        }
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            AddLine(counter++ + ": Random text");
        }
        public void AddLine(string text)
        {
            outputBox.AppendText(text);
            outputBox.AppendText("\u2028"); // Linebreak, not paragraph break
            outputBox.ScrollToEnd();
        }
    }
