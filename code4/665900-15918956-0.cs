    public class ViewModel : INotifyPropertyChanged
    {
        private string _status;
    
        public string Status
        {
            get { return _status; }
            set
            {
                if(_status == value)
                    return;
                _status = value;
    
                OnPropertyChanged("Status");
            }
        }
        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if(handler != null)
                handler(new PropertyChangedEventArgs(propertyName));
        }
        // ...
    }
