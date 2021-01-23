    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Messages { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>() { "1", "2", "3", "4" };
            DataContext = this;
        }
        private void ButtonAddUserControl_Click(object sender, RoutedEventArgs e)
        {
            sp.Children.Add(new UserControl1());
        }
        private void ButtonAddMessage_Click(object sender, RoutedEventArgs e)
        {
            Messages.Add((Messages.Count + 1).ToString());
        }
    }
