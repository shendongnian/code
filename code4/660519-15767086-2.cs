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
                // You can use the keyword "this" to access instance variables, but it is optional.
                this.filePaths = openFileDialog1.FileNames;
                this.imageNum = 0;
                lblFilePath.Content = this.filePaths[this.imageNum];
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // You may want to put some validation in here to prevent errors situations.
            // Validate that filePaths has been initialized.
            if (this.filePaths == null)
            {
               System.Windows.Forms.MessageBox.Show("No files paths to display.");
            }
            // Validate that imageNum can be incremented without IndexOutOfRangeException.
            else if (this.imageNum < this.filePaths.Length - 1)
            {
                this.imageNum++;
                lblFilePath.Content = this.filePaths[this.imageNum];
            }
            // Otherwise, loop back to the first file path.
            else
            {
                this.imageNum = 0;
                lblFilePath.Content = this.filePaths[this.imageNum];
            }
        }
    }
                
