    public partial class MainWindow : Window
    {
        private ObservableCollection<MyObject> myVar = new ObservableCollection<MyObject>();
        public MainWindow()
        { 
            InitializeComponent();
            Items.Add(new MyObject { Description = "Stack", Id = 5 });
            Items.Add(new MyObject { Description = "OverFlow", Id = 1 });
            Items.Add(new MyObject { Description = "StackOverFlow", Id = 2 });
            Items.Add(new MyObject { Description = "Stack", Id = 1 });
            Items.Add(new MyObject { Description = "Stack", Id = 0 });
            Items.Add(new MyObject { Description = "OverFlow", Id = 7 });  
        }
        public ObservableCollection<MyObject> Items
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
    public class MyObject
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return string.Format("Desc: {0}, Id: {1}", Description, Id);
        }
    }
