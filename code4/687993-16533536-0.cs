     public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
               if (value == null)
                  return false;
              else
              {
                  // Assumes a RowType has been passed as the bound value
                  string val = (string)value;
                  double doubleValue = double.TryParse(val, out doubleValue) ? doubleValue : 0;
                  return doubleValue * 40;
                  }
              }
          }
