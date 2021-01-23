    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItemVideoAudioDevices_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show("Parent's header text: " + ((MenuItem)menuItem.Parent).Header.ToString());
        }
    }
