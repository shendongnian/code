    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
        }
        /* private PROXY DP*/
        private static readonly DependencyProperty TextProperty =
            TextBox.TextProperty.AddOwner(typeof(FilePicker));
        /* public DP that will fire getter/setter for private DP  */
        public static readonly DependencyProperty SelectedFilePathProperty =
            DependencyProperty.Register("SelectedFilePath", typeof(string), typeof(FilePicker), new PropertyMetadata(default(string)));
        public string SelectedFilePath
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
