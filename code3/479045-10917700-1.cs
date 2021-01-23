    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        double sumValue = (double)value;
        if(sumValue==2)
        {
            return true;
        }
        return false;
    }
