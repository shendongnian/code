        public class Owner : PropertyChangedBase
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    
        public class Dog: PropertyChangedBase
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
    
            private Owner _owner;
            public Owner Owner
            {
                get { return _owner; }
                set
                {
                    _owner = value;
                    OnPropertyChanged("Owner");
                }
            }
    
            private string _kind;
            public string Kind
            {
                get { return _kind; }
                set
                {
                    _kind = value;
                    OnPropertyChanged("Kind");
                }
            }
        }
