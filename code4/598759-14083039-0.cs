    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is IEnumerable<ListBoxViewItem>) 
        {
          var l = (IEnumerable<ListBoxViewItem>)value;
          return l.Select(l.IsChecked);
        }
       
       return null;
    }
