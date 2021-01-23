    class VisibilityConverter : IValueConverter {
      public Boolean Invert { get; set; }
      Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
        var visible = Convert.ToBoolean(value) ^ Invert;
        return visible ? Visibility.Visible : Visibility.Collapsed;
      }
      Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
        throw NotImplementedException();
      }
    }
