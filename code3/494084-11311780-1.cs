    public static List<object> CreateEnumList(Enum enumeration)
    { 
        return Enum.GetValues(enumeration.GetType()).Cast<object>().ToList();
    }
    
