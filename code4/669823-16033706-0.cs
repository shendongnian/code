    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var viewModel = value as MyViewModel;
        if (viewModel != null)
        {
            string format = viewModel.FormattingString;
            return ...;
        } 
        return null;
    }
