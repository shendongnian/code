    class PersonViewModel : INotifyPropertyChanged {
        private int _Age;
        private int _Name;
        public int Age {
            get { return _Age; }
            set {
                if (_Age.Equals(value)) return;
                _Age = value;
                RaisePropertyChanged("Age");
            }
        }
        public string Name {
            get { return _Name; }
            set {
                if (_Name.Equals(value)) return;
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public Person CreatePerson() {
            return new Person(_Age, _Name);
        }
    }
