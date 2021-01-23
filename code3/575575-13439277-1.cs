    public class SaveIt : INotifyPropertyChanged {
    
        public event PropertyChangedEventHandler PropertyChanged;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        public string FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName {
            get { return _lastName; }
            set {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
