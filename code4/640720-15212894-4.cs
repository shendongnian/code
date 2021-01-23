    namespace WpfApplication7
    {
        public partial class MainWindow : Window
        {
    
            private Person _selectedPerson;
            private ObservableCollection<Person> _persons = new ObservableCollection<Person>();
    
            public MainWindow()
            {
                InitializeComponent();
                Items.Add(new Person { personID = "Stack" });
                Items.Add(new Person { personID = "Overflow" });
            }
    
            public ObservableCollection<Person> Items
            {
                get { return _persons; }
                set { _persons = value; }
            }
    
            public Person SelectedPerson
            {
                get { return _selectedPerson; }
                set { _selectedPerson = value; }
            }
    
        }
    
        public class Person
        {
            public string personID { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
        }
    }
