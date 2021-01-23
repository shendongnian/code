        public static T GetEnumValue<T, TExpected>(char value) where TExpected : Attribute
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                foreach (var field in type.GetFields())
                {
                    dynamic attribute = Attribute.GetCustomAttribute(field,
                        typeof(TExpected)) as TExpected;
                    if (attribute != null)
                    {
                        if (attribute.Value == value)
                        {
                            return (T)field.GetValue(null);
                        }
                    }
                }
            }
            return default(T);
        }
