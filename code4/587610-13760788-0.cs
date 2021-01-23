      public class PropertyToListConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    Type type = value.GetType();
                    PropertyInfo[] propertyList = value.GetType().GetProperties();
                    List<object> values =
                        (from property in propertyList
                         select GetValueOrElementName(value, property)).ToList();
                    return values;
        
                }
        
                private static object GetValueOrElementName(object value, PropertyInfo property)
                {
                    var propVal = property.GetValue(value, BindingFlags.Default, null, null, CultureInfo.InvariantCulture);
                    
                    if (property.PropertyType.IsGenericType && propVal != null)
                    {
                        Type type = property.PropertyType.GetGenericArguments().FirstOrDefault();
                        if (type == typeof(Child))
                            return new EnumerableClass() { Children = propVal as List<Child> };                   
                    }
        
                    if (propVal != null && !string.IsNullOrEmpty(propVal.ToString()))
                        return propVal;
        
        
                    return "Property["+ property.Name+"]";
        
                }
        
                
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
