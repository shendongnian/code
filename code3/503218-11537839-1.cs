    public NumbersToSumConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
          var numbers = value as BindingList<bool>();
          //Do your sum here.
       }
    
       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
          throw new NotImplementedException();
       }
    }
