    public clas s ObjectTypeToBooleanConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType().ToString() == (string)parameter)
            {
                return true;
            }
            return false;
        }
