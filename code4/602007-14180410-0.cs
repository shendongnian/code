    public static T ParseFlags<T>(string value) where T : struct
    {
        long result = 0L;
        string[] array;
        // Remove white spaces and delimit string if it is comma-separated
        if (ParseDelimitedString(value, ',', out array))
        {
            for (int i = 0; i < array.Length; i++)
            {
                T flag = default(T);
                // Check if value is member of enumeration
                if (Enum.TryParse<T>(array[i], out flag))
                {
                    result |= (long)flag;
                }
            }
        }
        else
        {
            switch (Type.GetTypeCode(Enum.GetUnderlyingType(typeof(T))))
            {
                // Remove hex characters and parse node's inner text
                case TypeCode.UInt32:
                    result = ParseUint(value);
                    break;
                case TypeCode.UInt64:
                    result = ParseUlong(value);
                    break;
            }
        }
        return (T)((object)result);
    }
