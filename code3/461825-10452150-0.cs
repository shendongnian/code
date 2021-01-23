    public class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
    
    public class ViewModel : NotificationObject
    {
        private int _MyProperty1;
        public int MyProperty1
        {
            get { return _MyProperty1; }
            set
            {
                if (value != _MyProperty1)
                {
                    _MyProperty1 = value;
                    OnMyProperty1Changed(new PropertyChangedEventArgs("MyProperty1"));
                }
            }
        }
    
        protected virtual void OnMyProperty1Changed(PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e);
        }
    
        private int _MyProperty2;
        public int MyProperty2
        {
            get { return _MyProperty2; }
            set
            {
                if (value != _MyProperty2)
                {
                    _MyProperty2 = value;
                    OnMyProperty2Changed(new PropertyChangedEventArgs("MyProperty2"));
                }
            }
        }
    
        protected virtual void OnMyProperty2Changed(PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e);
        }
    }
