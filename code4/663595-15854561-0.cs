     public class Updater
        {
            public static bool Update(object thisObj, object otherObj)
            {
                IEnumerable<PropertyInfo> props = thisObj.GetType().GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(UpdateElementAttribute)));
    
                bool change = false;
                foreach (var prop in props)
                {
                    object value = prop.GetValue(otherObj);
    
                    if (value != null && (value is string || string.IsNullOrWhiteSpace((string)value)))
                    {
                        if (!prop.GetValue(thisObj).Equals(value))
                        {
                            change = true;
                            prop.SetValue(thisObj, value);
                        }
                    }
                }
                return change;
            }
        }
