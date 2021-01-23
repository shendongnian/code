    public class PersonViewModel : INotifyPropertyChanged 
    {
        private Person person;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName) 
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public PersonViewModel(Person person)
        {
            this.person = person;
        }
    
        public int Age
        {
            get { return person.Age; }
            set
            {
                if (value != person.Age)
                {
                    person.Age = value;
                    OnPropertyChanged("Age");
                }
            }
        }
    
        public string FirstName
        {
            get { return person.FirstName; }
            set
            {
                if (value != person.FirstName)
                {
                    person.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
    
        public string LastName
        {
            get { return person.LastName; }
            set
            {
                if (value != person.LastName)
                {
                    person.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
    }
