    // your object
    public class Foo : INotifyPropertyChanged
    {
        private bool _bar;
    
        public bool Bar
        {
            get { return _bar; }
            set { 
                if (_bar == value)
                    return;
    
                _bar = value;
                OnPropertyChanged("Bar");
            }
        }
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
