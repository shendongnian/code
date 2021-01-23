    /// <summary>
  
    /// Convert a AttributeType into its wrapper class to display strings from resources
      /// in the selected language
      /// </summary>
      [ValueConversion(typeof(AttributeType), typeof(AttributeTypeWrapper))]
      public class AttributeTypeToWrapperConverter : IValueConverter {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          return new AttributeTypeWrapper((AttributeType)value);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
          return ((AttributeTypeWrapper)value).Type;
        }
      }
