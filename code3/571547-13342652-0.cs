    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            this.DataContext = this;
            BuildData();
            Company = "XYZ";
            testItemsControl.ItemsSource = Persons;
        }
        private void BuildData()
        {
            Persons.Add(new Person() { Name = "R1" });
            Persons.Add(new Person() { Name = "R2" });
            Persons.Add(new Person() { Name = "R3" });
        }
        public string Company { get; set; }
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }
    }
