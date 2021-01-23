    public class PersonConverter : IMultiValueConverter
        {   
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values != null && values.Length == 2)
                {
                    string name = values[0].ToString();
                    int age = (int)values[1];
    
                    return new Person { Name = name, Age = age }; 
                }
                return null;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
