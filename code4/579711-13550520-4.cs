    public partial class MainWindow : Window
    {
        private RowViewModel rvm = new RowViewModel(); //Here i have made new instance of RowViewModel, in your case you have to put your ViewModel instead of "new RowViewModel();";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = rvm; // this is very important step.
        }
    }
