    public object Convert(object value, Type targetType, object parameter, 
                          System.Globalization.CultureInfo culture)
    {
        return new SolidColorBrush(Colors.Red);
    }
    public object ConvertBack(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
    {
        return Binding.DoNothing;
    }
