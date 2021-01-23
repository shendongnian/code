    namespace myNameSpace
    {
       public class ListToStringConverter : IValueConverter
       {
          public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture) 
          {
             string returnValue = string.Empty; 
             List<string> targetList = value as List<string>; 
             
             foreach(string s in targetList)
             {
               if(!returnValue == string.Empty)
                  returnValue += ", " + s; 
               else 
                  returnValue += s; 
             }
             return returnValue; 
          }     
            public object ConvertBack(object value, Type targetType, 
		object parameter, System.Globalization.CultureInfo culture)
           {
              List<string> returnValue = new List<string>(); 
              
              string input = value as string; 
              returnValue.AddRange(input.Split(",")); 
              
              return returnValue; 
           }
       }
    } 
