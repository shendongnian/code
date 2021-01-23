    public static void GetPropertyChanges<T>(this T oldObj, T newObj)
            {
               
                Type type = typeof(T);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
    
                    object selfValue = type.GetProperty(pi.Name).GetValue(oldObj, null);
                    object toValue = type.GetProperty(pi.Name).GetValue(newObj, null);
                    if (selfValue != null && toValue != null)
                    {
                        if (selfValue.ToString() != toValue.ToString())
                        {
                         //do your code
                        }
                    }
                }
               
            }
