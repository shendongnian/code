    class ListStringConverter : IValueConverter
    {
       public bool IsListToString { get; set; }
        public ListStringConverter()
        {
            IsListToString = true;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return IsListToString ? FromListToString(value) : FromStringToList(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return IsListToString ? FromStringToList(targetListItem) : FromListToString(targetListItem);
        }
     
        public object FromListToString(object list)
        {
           .... // Conversion Logic
        }
        public object FromStringToList(object myString)
        {
           .... // Conversion Logic
        }
    }
