    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>
        {
            new Category { Name = "Squares"},
            new Category { Name = "Triangles"},
            new Category { Name = "Circles"},
        };
        public MainWindow()
        {
            InitializeComponent();
            NodeCategory = _categories.First();
            this.DataContext = this;
        }
        public IEnumerable<Category> Categories
        {
            get { return _categories; }
        }
        private Category _NodeCategory;
        public Category NodeCategory
        {
            get
            {
                return _NodeCategory;
            }
            set
            {
                _NodeCategory = value;
                OnPropertyChanged("NodeCategory");
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    [Serializable]
    public class Category : INotifyPropertyChanged
    {
        private string _Name;
        [XmlAttribute("Name")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
