    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _textRootDir;
        private string _textFilter = string.Empty;
        private string _selectedFile;
        private ObservableCollection<string> _myFiles = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        public ObservableCollection<string> MyFiles
        {
            get { return _myFiles; }
            set { _myFiles = value; }
        }
        public string SelectedFile
        {
            get { return _selectedFile; }
            set { _selectedFile = value; NotifyPropertyChanged("SelectedFile"); }
        }
        public string TextFilter
        {
            get { return _textFilter; }
            set { _textFilter = value; NotifyPropertyChanged("TextFilter"); }
        }
        public string TextRootDir
        {
            get { return _textRootDir; }
            set { _textRootDir = value; NotifyPropertyChanged("TextRootDir"); }
        }
        private void btnFolderBrowser_Click(object sender, RoutedEventArgs e)
        {
            GetFileStructure();
            MessageBox.Show("done!");
        }
        private void GetFileStructure()
        {
            string myDir = "";
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Browse to the root directory where the files are stored.";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                myDir = fbd.SelectedPath;
                try
                {
                    TextRootDir = fbd.SelectedPath;
                    MyFiles.Clear();
                    foreach (var file in Directory.GetFiles(myDir, TextFilter, SearchOption.AllDirectories))
                    {
                        MyFiles.Add(file);
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    return;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
