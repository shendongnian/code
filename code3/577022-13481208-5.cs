    public class Char : INotifyPropertyChanged
    {
        private int _iXCoordinate;
        public int iXCoordinate
        {
            get { return _iXCoordinate; }
            set
            {
                _iXCoordinate = value;
                OnPropertyChanged("iXCoordinate");
            }
        }
        private int _iYCoordinate;
        public int iYCoordinate
        {
            get { return _iYCoordinate; }
            set
            {
                _iYCoordinate = value;
                OnPropertyChanged("iYCoordinate");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
