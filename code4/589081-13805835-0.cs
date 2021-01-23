     public class DictionaryItemConverter : IMultiValueConverter {
          public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
               if(values != null && values.Length >= 2) {
                    var myDict = values[0] as IDictionary;
                    if(values[1] is string) {
                         var myKey = values[1] as string;
                         if(myDict != null && myKey != null) {
                              //the automatic conversion from Uri to string doesn't work
                              //return myDict[myKey];
                              return myDict[myKey].ToString();
                         }
                    }
                    else {
                         long? myKey = values[1] as long?;
                         if(myDict != null && myKey != null) {
                              //the automatic conversion from Uri to string doesn't work
                              //return myDict[myKey];
                              return myDict[myKey].ToString();
                         }
                    }
               }
               return Binding.DoNothing;
          }
          public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
               throw new NotSupportedException();
          }
     }
