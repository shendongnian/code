    public partial class MainWindow : Window
    {
        SomeObjectClass obj = new SomeObjectClass();
        public MainWindow()
        {
            InitializeComponent();
            txtName.DataContext = obj;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obj.Name = "Hello World";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            obj.Name = "Goobye World";
        }
    }
