    public class Square: PropertyChangedBase
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
    }
