    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            Items.Add(new CustomObject { Name = "Stack" });
            Items.Add(new CustomObject { Name = "Overflow" });
        }
        private ObservableCollection<CustomObject> _items = new ObservableCollection<CustomObject>();
        public ObservableCollection<CustomObject> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
    public class CustomObject
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
