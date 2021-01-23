    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel
            {
                Nodes = new ObservableCollection<Node>
                {
                    new Node
                    {
                        Text = "Parent 1",
                        Nodes = new ObservableCollection<Node>
                        {
                            new Node { Text = "Child 1.1"},
                            new Node { Text = "Child 1.2"},
                        }
                    },
                    new Node
                    {
                        Text = "Parent 2",
                        Nodes = new ObservableCollection<Node>
                        {
                            new Node { Text = "Child 2.1"},
                            new Node { Text = "Child 2.2"},
                        }
                    },
                }
            };
        }
    }
