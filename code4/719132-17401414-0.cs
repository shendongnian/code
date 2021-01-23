    private ObservableCollection<PersonModel> _peopleCollection;
    public ObservableCollection<PersonModel> PeopleCollection
    {
            get { return _peopleCollection; }
            set
            {
                _peopleCollection = value;
                RaisePropertyChanged("PeopleCollection");
            }
        }
	private void initPeople()
        {
            foreach (var person in PeopleCollection)
            {             
                person.PropertyChanged += PersonOnPropertyChanged;
           }
        }
	private void PersonOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if(propertyChangedEventArgs.PropertyName == "IsPersonSelected")
            {
		//Handle checked/unchecked person
            }
        }
	private bool _allPersonsSelected
        public bool AllPersonsSelected
        {
            get { return _allPersonsSelected; }
            set
            {
                _allPersonsSelected= value;
                RaisePropertyChanged("AllPersonsSelected");
                if (value)
                    SelectRows();
                else
                {
                    DeselectRows();
                }
            }
        }
        public void SelectRows()
        {
            foreach (var record in PeopleCollection)
                record.IsPersonSelected = true;
        }
        public void DeselectRows()
        {
            foreach (var record in PeopleCollection)
                record.IsPersonSelected = false;
        }
    }
