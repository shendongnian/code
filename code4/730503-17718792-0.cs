     namespace MCSearchMVVM
     {
         class MCBindButtonToComboBox : IValueConverter
         {
        
             public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
             {
                if (value == null) 
                   return false;
               return true;
              }
              public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
              {            throw new NotImplementedException();        }
          }
     }
