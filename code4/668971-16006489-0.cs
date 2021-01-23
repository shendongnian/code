    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SetBinding windows DataContext to this window
            new PopupWindow { DataContext = this }.Show();
        }
    }
