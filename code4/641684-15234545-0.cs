        static void printReturnedProperties(Object o)
        {
            PropertyInfo[] propertyInfos = null;
            propertyInfos = o.GetType().GetProperties();
            foreach (var item in propertyInfos)
            {
                var prop = item.GetValue(o);
                if(prop == null)
                {
                    Console.WriteLine(item.Name + ": NULL");
                }
                else
                {
                    Console.WriteLine(item.Name + ": " + prop.ToString());
                }
    
                if (prop is IEnumerable)
                {
                    foreach (var listitem in prop as IEnumerable)
                    {
                        Console.WriteLine("Item: " + listitem.ToString());
                    }
                }
            }
        }
