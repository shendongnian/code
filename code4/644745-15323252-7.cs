    public namespace MyNamespace
    {
        public class ViewModel: INotifyPropertyChanged
        {
            private string _name;
            public string Name 
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
            private bool _isActive;
            public bool IsActive
            {
                get
                {
                    return _isActive;
                }
                set
                {
                    _isActive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
        }
        public void NotifyPropertyChanged (string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
        }
    }
