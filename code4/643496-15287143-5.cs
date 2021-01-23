    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                Items.Add(new ComboBoxModel { Name = "Name" + i, State = "State" + i });
            }
        }
        private ObservableCollection<ComboBoxModel> _items = new ObservableCollection<ComboBoxModel>();
        public ObservableCollection<ComboBoxModel> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        
    }
    public class ComboBoxModel
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
