    public static class TypeConverter
    {
        private static Dictionary<Type, Type> Mappings;
    
        static TypeConverter()
        {
            Mappings = new Dictionary<Type, Type>
                {
                    {typeof (DbSpace), typeof (DmsSpace)},
                    {typeof (DbDirectory), typeof (DmsDirectory)},
                    {typeof (DbFile), typeof (DmsFile)}
                };
        }
    
        public static object Convert(object source, Type targetType)
        {
            var target = Activator.CreateInstance(targetType);
    
            foreach (PropertyInfo sourceProperty in source.GetType().GetProperties())
            {
                if (!sourceProperty.CanRead || (sourceProperty.GetIndexParameters().Length > 0))
                    continue;
    
                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);
    
                object value = sourceProperty.GetValue(source, null);
    
                if ((targetProperty != null) && (targetProperty.CanWrite))
                {
                    if (value != null)
                    {
                        Type valueType = value.GetType();
                        Type mappedTypeKey = Mappings.Keys.FirstOrDefault(valueType.IsAssignableFrom);
                        if (mappedTypeKey != null)
                        {
                            targetProperty.SetValue(target, Convert(value, Mappings[mappedTypeKey]), null);
                        }
                        else
                        {
                            targetProperty.SetValue(target, value, null);
                        }
                    }
                    else
                    {
                        targetProperty.SetValue(target, null, null);
                    }
                }
    
            }
            return target;
        }
    
        public static TTarget Convert<TTarget>(object source) where TTarget : class, new()
        {
            return Convert(source, typeof (TTarget)) as TTarget;
        }
    }
