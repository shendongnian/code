    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (value != null && value.ToString().Length > 0);
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new InvalidOperationException("IsNullConverter can only be used OneWay.");
    }
