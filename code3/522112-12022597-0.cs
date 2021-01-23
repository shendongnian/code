    public static List<string> GetValuesOf<T>()
    {
        List<string> levelsToReturn = new List<string>();
        var levels = Enum.GetValues(typeof(T)).Cast<T>();
        foreach (T value in levels)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            ValueOfEnum[] attribs = fieldInfo.GetCustomAttributes(typeof(ValueOfEnum), false) as ValueOfEnum[];
            levelsToReturn.Add(attribs.Length > 0 ? attribs[0].value : null);
        }
        return levelsToReturn;
    }
