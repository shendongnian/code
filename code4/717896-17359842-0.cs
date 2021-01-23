        class HiddenWithNoElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            if((value as IEnumerable<string>).Count() == 0)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }...
