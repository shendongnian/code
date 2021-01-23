     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = new Test { Test1 = "Test1", Test2 = "Test2" };
            DataGridTest.Items.Add(data);
        }
    }
    public class Test
    {
        public string Test1 { get; set; }
        public string Test2 { get; set; }
    }
