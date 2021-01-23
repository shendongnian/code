    public ObservableCollection<Person> Persons { get; private set; }
    ...
    private void DeleteRowCommand_Method()
    {
    	Persons.Remove(SelectedPerson);
    	Persons = new ObservableCollection<Person>(Persons);
    	OnPropertyChanged("Persons");
    }
    ...
