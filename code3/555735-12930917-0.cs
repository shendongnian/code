      class MyConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          var typeName = ((Class2)value).GetType().GetProperty((string) parameter);
          return typeName.ToString();
        }
