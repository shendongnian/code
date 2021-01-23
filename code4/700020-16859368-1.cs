    class IsRootNodeConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        TreeViewItem item = value as TreeViewItem;
        if (item == null || item.Parent == null)
          return false;
        return !Object.ReferenceEquals(value.GetType(), item.Parent.GetType());
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
