    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent(); 
            Categories.Add(new Category { Name = "Animals", Items = new List<string> { "Dog", "Cat", "Horse" } });
            Categories.Add(new Category { Name = "Vehicles", Items = new List<string> { "Car", "Truck", "Boat" } });
        
        }
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }
    }
    public class Category
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }
    }
