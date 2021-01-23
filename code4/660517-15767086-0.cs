    public partial class MainWindow : Window
    {
        // These can now be accessed from any method in this class.
        private string[] filepaths = null;
        private int imageNum = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.Filter = "Images (.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            bool? userClickedOK = openFileDialog1.ShowDialog();
            if (userClickedOK == true)
            {
                filePaths = openFileDialog1.FileNames;
                imageNum = 0;
                lblFilePath.Content = filePaths[imageNum];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            imageNum++;
            lblFilePath.Content = filePath[imageNum];
        }
    }
