            var prop = typeof (TestA).GetProperties();
            
            for (int i=0;i<prop.Count();i++)
            {
                var propertyInfo = prop[i];
                if (propertyInfo.PropertyType.Namespace != "System")
                {
                    if (propertyInfo.PropertyType.IsGenericType &&
                        propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof (List<>))
                    {
                        Type itemType = propertyInfo.PropertyType.GetGenericArguments()[0]; 
                        var listObjectProperties = itemType.GetProperties();
                        prop = prop.Union(listObjectProperties).ToArray();
                    }
                    else
                    {
                        var childProp = propertyInfo.PropertyType.GetProperties();
                        prop = prop.Union(childProp).ToArray();
                    }
                }
            }
