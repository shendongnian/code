    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        bool input = (bool)value;
        if (input)
        {
           return DependencyProperty.UnsetValue;
        }
        return Brushes.Red;
    }
