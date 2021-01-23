    public class OptionValue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ...
        public string Display { get { return _mDisplay; } set { _mDisplay = value; OnPropChanged("Display"); } }
        public object Value { get { return _mValue; } set { _mValue = value; OnPropChanged("Value"); } }
        ...
        public void OnPropChanged(string propName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
