          Here is something that I tried. It works albeit it's a little slow on lager object graphs. One could use expression trees           which are harder to get but give a really impressive performance.
          'private static IEnumerable<Tuple<PropertyInfo, PropertyInfo>> MapProperties(Type source, Type target)
            {
                var targetProperies = target.GetProperties();
                foreach (var property in source.GetProperties())
                {
                    var conversionAttribute =
                        property.GetCustomAttributes(typeof (ConvertAttribute), false).FirstOrDefault() as
                        ConvertAttribute;
                    if (conversionAttribute == null)
                        throw new InvalidOperationException(
                            String.Format("Source property {0} doesn't have ConvertAttribute defined", property.Name));
                    var targetProperty = targetProperies.FirstOrDefault(p => p.Name == conversionAttribute.Name);
                    if (targetProperty == null)
                        throw new InvalidOperationException(String.Format(
                            "Target type doesn't have {0} public property", conversionAttribute.Name));
                    yield return Tuple.Create(targetProperty, property);
                }
            }
            public static bool IsIList(Type type)
            {
                return type.GetInterface("System.Collections.Generic.IList`1") != null;
            }
            private static object Convert(object source, Type resaultType)
            {
                var resault = Activator.CreateInstance(resaultType);
                var sourceType = source.GetType();
                if (IsIList(resaultType) && IsIList(sourceType))
                {
                    var sourceCollection = source as IList;
                    var targetCollection = resault as IList;
                    var argument = resaultType.GetGenericArguments()[0];
                    if (argument.IsAssignableFrom(sourceType.GetGenericArguments()[0]))
                    {
                        foreach (var item in sourceCollection)
                        {
                            targetCollection.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var item in sourceCollection)
                        {
                            targetCollection.Add(Convert(item, argument));
                        }
                    }
                }
                else
                {
                    foreach (var map in MapProperties(sourceType, resaultType))
                    {
                        if (map.Item1.PropertyType.IsAssignableFrom(map.Item2.PropertyType))
                        {
                            map.Item1.SetValue(resault, map.Item2.GetValue(source, null), null);
                        }
                        else
                        {
                            map.Item1.SetValue(resault,
                                               Convert(map.Item2.GetValue(source, null), map.Item1.PropertyType), null);
                        }
                    }
                }
                return resault;
            }'
