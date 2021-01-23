    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var enu = (IEnumerable)value;
        return enu.Cast<object>().Any() ? Visibility.Visible : Visibility.Collapsed;
    }
