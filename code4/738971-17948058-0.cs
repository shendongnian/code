    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    public class ResizeModeConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return (bool)value ? ResizeMode.CanResize : ResizeMode.CanMinimize;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
      }
    }
