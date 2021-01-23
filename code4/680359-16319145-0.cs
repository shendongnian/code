     private static void ResolveTypeAndValue(object obj)
        {
            var type = obj.GetType();
            foreach (var p in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                {
                    var currentObj = p.GetValue(obj);
                    ResolveTypeAndValue(currentObj);
                }
                else
                    Console.WriteLine("The value of {0} property is {1}", p.Name, p.GetValue(obj));
            }
        }
