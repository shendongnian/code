    public class DataItem
    {
        public bool Column1 { get; set; }
        public string Column2 { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataItem item = new DataItem();
            item.Column1 = true;
            item.Column2 = "test";
            dataGrid.Items.Add(item);
        }
    }
