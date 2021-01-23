    public partial class MainWindow : Window
    {
        private Person _selectedPerson;
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Persons.Add(new Person { Name = "Stack" });
            Persons.Add(new Person { Name = "Overflow" });
        }
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedPerson.IsEditing = true;
        }
    }
