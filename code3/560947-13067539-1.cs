     public class MyConverter : IValueConverter
     {
         object Convert(value, parameter ..)
         {
              var dict 
                  = ((FrameworkElement)parameter).DataContext 
                      as Dictionary<string, string>)parameter;
              return (dict[value.ToString()];
         }
         object ConvertBack (value, parameter ..)
         {
            var dict 
                  = ((FrameworkElement)parameter).DataContext 
                      as Dictionary<string, string>)parameter;
            
            foreach(var item in dict)
            {
                if (item.Value == value)
                {
                    return item.Key;
                }
            }
         }
     }
