    public partial class EntitiesView : UserControl
    {
        private string _name2;
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }
        public EntitiesView()
        {
            Name2 = "abcdef";
            DataContext = this;
            InitializeComponent();
        }
    }
