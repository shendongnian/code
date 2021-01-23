    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            this.DataContext = this;
            str = = new ObservableCollection<string>();
            str.Add("dhaval");
            str.Add("ravinder");
        }
        public ObservableCollection<string> str { get; set; }
 
    }
