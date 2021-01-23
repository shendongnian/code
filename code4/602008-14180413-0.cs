    public static T ParseFlags<T>(string value) where T : struct
    {
        T result;
        ulong temp;
        if (Enum.TryParse(value, out result))
        {
            return result;
        }
            
        string hexNum = value.StartsWith("0x") ? value.Substring(2) : value;
        if (ulong.TryParse(hexNum, NumberStyles.HexNumber, null, out temp))
        {
            return (T)Enum.ToObject(typeof(T), temp);
        }
        
        throw new ArgumentException("value could not be parsed");
    }
