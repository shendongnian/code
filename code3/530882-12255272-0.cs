    public class Station : INotifyPropertyChanged
    {
        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }
        /* INotifyPropertyChanged implementation */
    }
    public class StationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formattedValue = // Add the plus here
            return formattedValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string numericValue = // Parse the optional '+' out of the value
            decimal stationValue = decimal.Parse(numericValue);
        }
    }
