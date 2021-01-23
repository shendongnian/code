    public class MyBindableObject : INotifyPropertyChanged
    {
        private string _dateStr;
        public string DateStr
        {
            get { return _dateStr; }
            set
            {
                if (_dateStr == value)
                    return;
                _dateStr = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DateStr"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
