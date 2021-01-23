    public partial class BarChart : UserControl
    {
        private List<BarItem> _items;
        public List<BarItem> Items
        {
            get { return _items ?? (_items = new List<BarItem>()); }
            set { _items = value; }
        }
        public BarChart()
        {
            InitializeComponent();
        }
    }
