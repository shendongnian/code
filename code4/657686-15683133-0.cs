    public static Dictionary<T, string> EnumToDictionary<T>()
            where T : struct
    {
        Type enumType = typeof(T);
    
        // Can't use generic type constraints on value types,
        // so have to do check like this
        if (enumType.BaseType != typeof(Enum))
            throw new ArgumentException("T must be of type System.Enum");
    
        Dictionary<T, string> enumDL = new Dictionary<T, string>();
        //foreach (byte i in Enum.GetValues(enumType))
        //{
        //    enumDL.Add((T)Enum.ToObject(enumType, i), Enum.GetName(enumType, i));
        //}
        foreach (T val in Enum.GetValues(enumType))
        {
            enumDL.Add(val, val.ToString());
        }
        return enumDL;
    }
