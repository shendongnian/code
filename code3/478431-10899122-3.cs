    using System.Reflection;  // reflection namespace
    
    public static List<Type> GetClassPropertyNames(Type myClass)
            {
                PropertyInfo[] propertyInfos;
                propertyInfos = myClass.GetProperties(BindingFlags.Public);
                
                List<Type> propertyTypeNames = new List<Type>();
    
                // write property names
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    propertyTypeNames .Add(propertyInfo.PropertyType);
                }
    
                return propertyNames;
    
            }
