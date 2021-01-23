    public partial class MainWindow : Window
    {
        public ObservableCollection<Data> DataSet { get; set; }
        public MainWindow()
        {
            DataSet = new ObservableCollection<Data>();
            DataSet.Add(new Data { Name = "First" });
            DataSet.Add(new Data { Name = "Second" });
            DataSet.Add(new Data { Name = "Third" });
            InitializeComponent();
            DataContext = this;
        }
    }
    public class Data
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
