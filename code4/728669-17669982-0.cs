    public class NullToVisibilityConverter : IValueConverter {
    
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
    
        bool isVisible = value == null ? false : true;
    
        if (isVisible) {
          string stringValue = value as string;
          if (stringValue != null) {
            isVisible = string.IsNullOrEmpty(stringValue) ? false : true;
          }
        }
                
        if (System.ComponentModel.DesignerProperties.IsInDesignTool) {
          return Visibility.Visible;
        }
    
        return isVisible ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
      }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                throw new NotImplementedException();
            }
        }
