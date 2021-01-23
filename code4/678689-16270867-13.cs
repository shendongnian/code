    public partial class ActionsListBoxSample : Window
    {
        public ActionsViewModel ViewModel { get; set; }
        public ActionsListBoxSample()
        {
            InitializeComponent();
            DataContext = ViewModel = new ActionsViewModel();
        }
    }
