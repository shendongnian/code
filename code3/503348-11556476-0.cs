    static object GetPropertyValue(object obj, string propertyName)
            {
                var objType = obj.GetType();
                var prop = objType.GetProperty(propertyName);
    
                return prop.GetValue(obj, null);
            }
            static void SetPropertyValue(object obj, string propertyName, int values)
            {
                var objType = obj.GetType();
                var prop = objType.GetProperty(propertyName);
                prop.SetValue(obj, values, null);
            }
