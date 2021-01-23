        public static object TryConvertToType(this object source, Type destinationType, object defaultValue = null)
        {
            try
            {
                if (source == null)
                    return defaultValue;
                if (destinationType == typeof(bool))
                {
                    bool returnValue = false;
                    if (!bool.TryParse(source.ToString(), out returnValue))
                    {
                        return Convert.ChangeType(source.ToString() == "1", destinationType);
                    }
                    else
                    {
                        return Convert.ChangeType(returnValue, destinationType);
                    }
                }
                else if (destinationType.IsSubclassOf(typeof(Enum)))
                {
                    try
                    {
                        return Enum.Parse(destinationType, source.ToString());
                    }
                    catch
                    {
                        return Enum.ToObject(destinationType, source);
                    }
                }
                else if (destinationType == typeof(Guid))
                {
                    return Convert.ChangeType(new Guid(source.ToString().ToUpper()), destinationType);
                }
                else if (destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    Type genericType = destinationType.GetGenericArguments().First();
                    return Convert.ChangeType(source, genericType);
                }
                else if (source.GetType().IsSubclassOf(destinationType))
                {
                    return Convert.ChangeType(source, destinationType);
                }
                else if (!source.GetType().IsValueType
                    && source.GetType() != typeof(string)
                    && destinationType == typeof(string))
                {
                    return Convert.ChangeType(source.GetType().Name, destinationType);
                }
                else
                {
                    return Convert.ChangeType(source, destinationType);
                }
            }
            catch
            {
                return defaultValue;
            }
        }
