    public partial class MainWindow : Window
    {
        public List<MyClass> Lst
        {
            get;
            set;
        }
 
        public MainWindow()
        {
            InitializeComponent();
            Lst.Add(new MyClass { ID = 1, Name = "User1", Age = 16 });
            Lst.Add(new MyClass { ID = 2, Name = "User2", Age = 20});
            Lst.Add(new MyClass { ID = 3, Name = "User3", Age = 42});
            
            DataContext = this;
        }
    }
