    abstract class Base {
    }
    class ClassA : Base, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _property;
        public string ClassAProperty {
            get {
                return _property;
            }
            set {
                _property = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClassAProperty"));
            }
        }
    }
    class ClassB : Base, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _property;
        public string ClassBProperty {
            get {
                return _property;
            }
            set {
                _property = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ClassBProperty"));
            }
        }
    }
