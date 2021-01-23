    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private ObservableCollection<dynamic> _listBoxItems = new ObservableCollection<dynamic>();
        public ObservableCollection<dynamic> ListBoxItems
        {
            get { return _listBoxItems; }
            set { _listBoxItems = value; }
        }
        public List<River> Rivers
        {
            get
            { 
                return new List<River>
                { 
                   new River { Name = "River1" } ,
                   new River { Name = "River2"}
                };  
            }
        }
        public List<City> Cities
        {
            get
            {
                return new List<City>
                { 
                   new City { Name = "City1" } ,
                   new City { Name = "City2"}
                };  
            }
        }
        private void button_City_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItems.Clear();
            Cities.ForEach(i => ListBoxItems.Add(i));
        }
        private void button_River_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItems.Clear();
            Rivers.ForEach(i => ListBoxItems.Add(i));
        }
    }
    public sealed class City
    {
        public string Name { get; set; }
    }
    public sealed class River
    {
        public string Name { get; set; }
    }
