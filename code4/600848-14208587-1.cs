    Person _currentPerson;
            ReadOnlyCollection<Person> _people;
            ObservableCollection<WorkspaceViewModel> _workspaces;
            
            string _curuser;
            string u = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            public string CurrentUser { get; set; }
            
            ExpensesEntities ee = new ExpensesEntities();
    public ReadOnlyCollection<Person> People
            {
                get
                {
                    if (_people == null)
                    {
                        List<Person> persns = this.GetPeople();
                        _people = new ReadOnlyCollection<Person>(persns);
                    }
                    return _people;
                }
            }
