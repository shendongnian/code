    public partial class Account : Window
    {
        private ObservableCollection<Accounts> AccountList = new ObservableCollection<Accounts>();
        public Account()
        {
            InitializeComponent();        
            this.DataContext= new AccountListViewModel();
        }
    }
