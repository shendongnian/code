    public partial class Users : Window
    {
        public Users()
        {
            str = new ObservableCollection<string>();
            InitializeComponent();
            //this.DataContext = this;
            str.Add("dhaval");
            str.Add("ravinder");
        }
        public ObservableCollection<string> str { get; set; }
    }
