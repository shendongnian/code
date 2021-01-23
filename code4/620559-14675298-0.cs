    public MainWindow()
    {
        InitializeComponent();
        listBox1.ItemsSource = new List<ListItemViewModel>
        {
            new ListItemViewModel { Name = "Foo", Description = "Foo description" },
            new ListItemViewModel { Name = "Bar", Description = "Bar description" }
        };
    }
    public class ListItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
