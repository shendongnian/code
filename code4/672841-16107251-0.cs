        public class YourDataContext : INotifyPropertyChanged
        {
            private object _myvalue;
            public object myvalue
            {
                get
                {
                    return _myvalue;
                }
                set
                {
                    if (_myvalue == value)
                        return;
                  
                    _myvalue = value;
                    OnPropertyChanged("myvalue");
                }
            }
            public event PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, 
                                    new PropertyChangedEventArgs(propertyName));
                }
            }
        }
