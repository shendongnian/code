    namespace WpfApplication5
    {
    public partial class MainWindow : Window
    {
        private List<Item> _items;
        public List<Item> Items
        {
            get { return _items ?? (_items = new List<Item>()); }
        }
        public MainWindow()
        {
            InitializeComponent();
            Items.Add(new Item() {Description = "Base metal Thickness"});
            
            for (var i = 32; i > 0; i--)
            {
                Items.Add(new Item() {Description = "Metal Specification " + i.ToString()});
            }
            Items.Add(new Item() { Description = "Base metal specification" });
            DataContext = this;
        }
    }
    public class Item: INotifyPropertyChanged
    {
        private List<string> _values;
        public List<string> Values
        {
            get { return _values ?? (_values = new List<string>()); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Description { get; set; }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public Item()
        {
            Values.Add("Value1");
            Values.Add("Value2");
            Values.Add("Value3");
            Values.Add("Value4");
            Values.Add("Value5");
            Values.Add("Value6");
        }
    }
    }
