    public static string GetDescription(this Enum theEnum)
    {
        if (theEnum == null)
            return string.Empty;
        return GetDescriptionAttribute(theEnum);
    }
    enum Test { blah }
   
    Test? q = null;
    q.GetDescription(); // => theEnum parameter is null
