        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int length = (int)value;
            return length > 0 ? Visibility.Visible : Visibilty.Collapsed;
        }
