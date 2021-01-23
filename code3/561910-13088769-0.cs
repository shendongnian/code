    public class MyClass : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
