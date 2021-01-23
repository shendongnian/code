        public class WatchRow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _color;
        decimal _lTP;
        public WatchRow(decimal LTP, string color)
        {
            this.LTP = LTP;
            this.Color = color;
        }
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged(_color);
            }
        }
        public decimal LTP
        {
            get { return _lTP; }
            set
            {
                _lTP = value;
                OnPropertyChanged(_lTP.ToString());
            }
        }
        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
