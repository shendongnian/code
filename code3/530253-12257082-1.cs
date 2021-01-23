    public class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedPerson;
        public MainViewModel()
        {
            AddCommand = new RelayCommand(AddAndSelectePerson);
            Persons = new DataTable();
            Persons.Columns.Add("FirstName");
            Persons.Columns.Add("LastName");
            Persons.Rows.Add("Alexandr", "Puskin");
            Persons.Rows.Add("Lev", "Tolstoy");
        }
        public ICommand AddCommand { get; private set; }
        public int SelectedIndex
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedIndex");
            }
        }
        public DataTable Persons { get; private set; }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private void AddAndSelectePerson()
        {
            Persons.Rows.Add();
            SelectedIndex = Persons.Rows.Count - 1;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _actionToExecute;
        public RelayCommand(Action actionToExecute)
        {
            _actionToExecute = actionToExecute;
        }
        #region ICommand Members
        public void Execute(object parameter)
        {
            _actionToExecute();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        #endregion
    }
    public class Person
    {
        public Person()
        {
        }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
