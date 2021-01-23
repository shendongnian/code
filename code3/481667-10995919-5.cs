    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
            TextBox_FilePath.DataContext = this;
        }
        public static readonly DependencyProperty SelectedFilePathProperty =
            DependencyProperty.Register("SelectedFilePath", typeof(string), typeof(FilePicker), new PropertyMetadata(default(string)));
        public string SelectedFilePath
        {
            get { return (string)GetValue(SelectedFilePathProperty); }
            set { SetValue(SelectedFilePathProperty, value); }
        }
        public string FilePath
        {
            get { return SelectedFilePath; }
            set { SelectedFilePath = value; }
        }
    }
