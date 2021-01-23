    using System.Reflection;  // reflection namespace
    
    public static List<String> GetClassPropertyNames(Type myClass)
            {
                PropertyInfo[] propertyInfos;
                propertyInfos = myClass.GetProperties(BindingFlags.Public);
                
                List<String> propertyNames = new List<string>();
    
                // write property names
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    propertyNames.Add(propertyInfo.Name);
                }
    
                return propertyNames;
    
            }
