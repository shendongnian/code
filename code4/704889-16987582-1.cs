    public class ViewModel : INotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                if (null != PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value)
            {
                if (value.ToString() == "1")
                    return true;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
