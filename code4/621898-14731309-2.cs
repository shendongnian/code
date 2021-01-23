    public partial class MainWindow : Window
    {
        public ObservableCollection<int> GridProperties { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            GridProperties = new ObservableCollection<int>();
            GridProperties.Add(0);
            DataContext = this;
        }
        private void Rect_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            GridProperties[0] = 1;
        }
    }
