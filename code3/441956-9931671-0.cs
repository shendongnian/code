    public class PersonViewModel : INotifyPropertyChanged
    {
        Person _person;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public PersonViewModel(Person person)
        {
            _person = person;
        }
        public int Age
        {
            get
            {
                return _person.Age;
            }
            set
            {
                _person.Age = value;
                OnPropertyChanged("Age");
            }
        }
    }
