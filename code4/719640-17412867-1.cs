    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e) {
            ((TabItem)MyTabControl.Items[0]).Header = "Changed!";
        }
    }
