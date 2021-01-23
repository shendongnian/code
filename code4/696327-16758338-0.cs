    public class MyOwnClass : INotifyPropertyChanged
    {
        private string _username;
        public string username 
        {
            get { return _username ; }
            set
            {
                if (_userName == value) return;
                _userName = value;
                NotifyPropertyChanged("username");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }  
    }
