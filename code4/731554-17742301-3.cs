    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = new MyDataContext();
        }
    }
    
        class MyDataContext
        {
            public ObservableCollection<Outer> Outers { get; set; }
    
    
            public MyDataContext()
            {
                Outers = new ObservableCollection<Outer>();
                Outers.Add(new Outer() { Name = "Herp" });
                Outers.Add(new Outer() { Name = "Derp" });
            }
        }
    
        class Outer
        {
            public string Name { get; set; }
            public ObservableCollection<Inner> Actions { get; set; }
    
            public Outer()
            {
                Actions = new ObservableCollection<Inner>();
                Actions.Add(new Inner { Name = "Test1" });
                Actions.Add(new Inner { Name = "Test2" });
                Actions.Add(new Inner { Name = "Test3" });
                Actions.Add(new Inner { Name = "Test4" });
                Actions.Add(new Inner { Name = "Test5" });
                Actions.Add(new Inner { Name = "Test6" });
                Actions.Add(new Inner { Name = "Test7" });
            }
        }
    
    
        class Inner
        {
            public string Name { get; set; }
            public ICommand OnClick { get; set; }
        }
