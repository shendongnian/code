    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        string parameterString = parameter as string;
        if (!string.IsNullOrEmpty(parameterString))
        {
            string[] parameters = parameterString.Split(new char[]{'|'});
            // Now do something with the parameters
        }
    }
