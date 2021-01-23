    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();
            newWindow.RaiseCustomEvent += new EventHandler<CustomEventArgs>(newWindow_RaiseCustomEvent);
            newWindow.Show();
          
        }
        void newWindow_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            this.Title = e.Message;
        }
    }
