    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MyType type = new MyType()
                {
                    Things = new List<MyThing>() {new MyThing() {Name = "aaa"}, new MyThing() {Name = "bbb"}}
                };
            content.Content = type;
        }
    }
    public class MyType
    {
        public MyThing SelectedThing { get; set; }
        public List<MyThing> Things { get; set; }
    }
    public class MyThing
    {
        public string Name { get; set; }
    }
