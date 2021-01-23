    public class Range : INotifyPropertyChanged
    {
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        private string _range_name;
        private string _range_description;
        private int _min;
        private int _max;
        public string range_name
        {
            get { return this._range_name; }
            set
            {
                _range_name = value;
                OnPropertyChanged("range_name");  
            }  // Call OnPropertyChanged whenever the property is updated
        }
        public string range_description
        {
            get { return this._range_description; }
            set
            {
                _range_description = value;
                OnPropertyChanged("range_description");
            }
        }
        public int min
        {
            get { return this._min; }
            set
            {
                _min=value;
                OnPropertyChanged("min");
            }
        }
        public int max
        {
            get { return this._max; }
            set
            {
                _max = value;
                OnPropertyChanged("max");
            }
        }
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
