    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = new TextBox();
            Grid.SetRow(tb, 1);
            Grid.SetColumn(tb, 1);
            tb.Text = "dynamic is not visible, if NavBar here...";
            ContentGrid.Children.Add(tb);
        }
    }
