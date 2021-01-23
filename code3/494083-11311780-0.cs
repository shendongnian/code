    public static List<object> CreateEnumList(Enum enumeration)
    { 
        return Enum.GetValues(typeof(enumeration)).Cast<object>().ToList();
    }
    
