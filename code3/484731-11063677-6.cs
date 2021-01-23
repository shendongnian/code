    public partial class MainWindow : Window
    {
        private ObservableCollection<ToolboxItem> items;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            items = new ObservableCollection<ToolboxItem>
            {
                new TextToolboxItem { Name = "primaryText", 
                                      Text = "Hello world", 
                                      Position = new Point(40, 130) },
                new TextToolboxItem { Name = "secondaryText", 
                                      Text = "Hello world (again)", 
                                      Position = new Point(200, 30) },
                new RectangleToolboxItem { Position = new Point(50,300), 
                                           Name = "Rect1", 
                                           Bounds = new Rect(0, 0, 150, 85) },
            };
        }
        public ObservableCollection<ToolboxItem> Items { get { return items; } }
    }
