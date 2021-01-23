        static Boolean TryParseString<T>(
            String stringValue, ref T value)
        {
            Type typeT = typeof(T);
            
            if (typeT.IsPrimitive)
            {
                value = (T)Convert.ChangeType(stringValue, typeT);
                return true;
            }
            else if (typeT.IsEnum)
            {
                value = (T)System.Enum.Parse(typeT, stringValue); // Yeah, we're making an assumption
                return true;
            }
            else
            {
                var convertible = value as IConvertible;
                if (convertible != null)
                {
                    return (value as IConvertibleFromString).FromString(stringValue);
                }
            }
            
            return false;
        }
