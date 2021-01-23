    public partial class MainWindow : Window
    {
        public ObservableCollection<string> ListBoxStuff { get; set; }
        public ObservableCollection<string> ComboBoxStuff { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ListBoxStuff = new ObservableCollection<string>() { "one", "two", "three" };
            ComboBoxStuff = new ObservableCollection<string>() { "four", "five", "six" };
            this.DataContext = this;
        }
    }
