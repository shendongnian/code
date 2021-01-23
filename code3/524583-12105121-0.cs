    public class TestObject : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _xmlText;
        public string XmlText
        {
            get
            {
                return _xmlText;
            }
            set
            {
                if (value != _xmlText)
                {
                    _xmlText = value;
                    NotifyPropertyChanged("XmlText");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "XmlText")
                {
                    if (XmlText.Length > 5)
                        result = "Too much long!";
                }
                return result;
            }
        }
    }
