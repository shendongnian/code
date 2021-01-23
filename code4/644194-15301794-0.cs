    public PeopleConnector()
    {
        People = new ObservableCollection<Person>();
        People.Add(new Person { Name = "Iris", About = "Developer that loves Metro style" });
        People.Add(new Person { Name = "Paul", About = "DBA with a thing for SQL Server 2012" });
        NewPerson = new Person();
        _addPersonCommand = new DelegateCommand(AddNewPerson);
    }
    private readonly DelegateCommand _addPersonCommand;
    public ICommand AddPersonCommand
    {
        get { return _addPersonCommand; }
    }
