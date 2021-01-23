    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        public ICommand Open { get; set; }    //Need to implement, maybe could be a RelayCommand or DelegateCommand, you may search in the internet
        public ICommand Save { get; set; }
    }
