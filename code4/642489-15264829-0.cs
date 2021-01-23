    public class myObject : INotifyPropertyChanged
    {
        // This will probably be needed to be moved elsewhere depending of your strategy
        public static myObject GlobalObject = new myObject();
        bool _myValue;
        public bool myValue
        {
            get
            {
                return _myValue;
            }
            set
            {
                _myValue = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("myValue"));
                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
