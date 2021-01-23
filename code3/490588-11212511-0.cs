    using System;
    using System.Linq;
    using System.Reflection;
    
    class Test    
    {
        // Note: this uses implementation details of anonymous
        // types, and is basically horrible.
        static object[] ConvertAnonymousType(object value)
        {
            // TODO: Validation that it's really an anonymous type
            Type type = value.GetType();
            var genericType = type.GetGenericTypeDefinition();
            var parameterTypes = genericType.GetConstructors()[0]
                                            .GetParameters()
                                            .Select(p => p.ParameterType)
                                            .ToList();
            var propertyNames = genericType.GetProperties()
                                           .OrderBy(p => parameterTypes.IndexOf(p.PropertyType))
                                           .Select(p => p.Name);
                    
            return propertyNames.Select(name => type.GetProperty(name)
                                                    .GetValue(value, null))
                                .ToArray();
                        
        }
        
        static void Main()
        {
            var value = new { A = "a", Z = 10, C = "c" };
            var array = ConvertAnonymousType(value);
            foreach (var item in array)
            {
                Console.WriteLine(item); // "a", 10, "c"
            }
        }
    }
