    public partial class MainWindow : Window
    {
        public ObservableCollection<Wrapper<bool>> MyBooleanCollection { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyBooleanCollection = new ObservableCollection<Wrapper<bool>>() { false, true, true, false, true };
        }
    }
