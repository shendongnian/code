        public bool SetValue(IList<string> values, object options)
        {
            var elementType = _property.PropertyType.GetElementType();
            var propertyType = elementType;
            if (propertyType.IsGenericType &&
            propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                propertyType = propertyType.GetGenericArguments()[0];
            }
            var array = Array.CreateInstance(elementType, values.Count);
            for (var i = 0; i < array.Length; i++)
            {
                try
                {
                    if (propertyType.BaseType.Equals(typeof (System.Enum)))
                    {
                        array.SetValue(Enum.Parse(propertyType, values[i]), i);
                        _property.SetValue(options, array, null);
                    }
                    else
                    {
                        array.SetValue(Convert.ChangeType(values[i], elementType, _parsingCulture), i);
                        _property.SetValue(options, array, null);
                    }
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return ReceivedValue = true;
        }
