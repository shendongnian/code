    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public TreeViewModel TreeModel
        {
            get
            {
                return new TreeViewModel
                {
                    Items = new ObservableCollection<NodeViewModel>{
                               new NodeViewModel { Name = "Root", Children =  new ObservableCollection<NodeViewModel> {
                                  new NodeViewModel { Name = "Level1" ,  Children = new ObservableCollection<NodeViewModel>{ 
                                      new NodeViewModel{ Name = "Level2"}}} } }}
                };
            }
        }
    }
    
    public class TreeViewModel
    {
        public ObservableCollection<NodeViewModel> Items { get; set; }
    }
    
    public class NodeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<NodeViewModel> Children { get; set; }
    }
