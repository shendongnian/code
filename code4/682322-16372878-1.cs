     public object Convert(object value, Type targetType, object parameter,  System.Globalization.CultureInfo culture)
      {
          if (value == null)
             return null;
          var list = (value as ICollection<string>).Where((x) => x.StartsWith("A")).ToList();
          return list;
       }
