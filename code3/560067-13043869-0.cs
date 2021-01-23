    public class MyConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, 
                                          System.Globalization.CultureInfo culture)
       {
          string hierarchy = String.Empty;
          if(value != DependencyProperty.UnsetValue)
          {
             MyTreeItem item = value;
             hierarchy = value.Description;
             MyTreeItem parentItem = item.Parent;
             while(parentItem != null)
             {
                hierarchy = string.Format("{0) -> {1}", parentItem.Description, 
                                                           hierarchy);
                parentItem = parentItem.Parent;
             }
          }
          return hierarchy;
       }
    
       public object ConvertBack(object value, Type targetType, object parameter,
                                      System.Globalization.CultureInfo culture)
       {
          throw new NotImplementedException();
       }
    }
