    public partial class MainWindow : Window
        {
            ObservableCollection<Person> mPeople = new ObservableCollection<Person>();
    
            public ObservableCollection<Person> People
            {
                get
                {
                    return mPeople;
                }
            }
    
            public MainWindow()
            {
                DataContext = this;
                mPeople.Add( new Employee{ Name = "x" , ManagerName = "foo"});
                mPeople.Add( new Manager { Name = "y"});
    
                InitializeComponent();
            }
        }
