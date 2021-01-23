    public class MyDataClass : INotifyPropertyChanged
    {
        public int Day1
        {
            get { return _day1; }
            set 
            {
                _day1 = value;
                UpdateProperties();
            }
        }
        public int Day2
        {
            get { return _day2; }
            set 
            {
                _day2 = value;
                UpdateProperties();
            }
        }
        // etc, repeat for the next three 'Day' properties
        private void UpdateProperties()
        {
            //adjust the private backing members for each property:
            _day1 = someValue;
            _day2 = someOtherValue;
    
            OnPropertyChanged("Day1");
            OnPropertyChanged("Day2");
            //etc, notify for each property that you adjusted
        }
        private void OnPropertyChanged(string propertyName)
        {
            handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangeEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private int _day1, _day2, //etc... ;
    }
