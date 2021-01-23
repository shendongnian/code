      public class Connection: INotifyPropertyChanged
        {
            private string _computerName;
            public string ComputerName
            {
                get { return _computerName; }
                set
                {
                    _computerName = value;
                    OnPropertyChanged("ComputerName");
                }
            }
    
            private string _ipAddress;
            public string IPAddress
            {
                get { return _ipAddress; }
                set
                {
                    _ipAddress = value;
                    OnPropertyChanged("IPAddress");
                }
            }
    
            private DateTime _connectionTime;
            public DateTime ConnectionTime
            {
                get { return _connectionTime; }
                set
                {
                    _connectionTime = value;
                    OnPropertyChanged("ConnectionTime");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
