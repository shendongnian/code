    /// <summary>
    /// Check that properties are equal for two instances
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="other"></param>
    /// <param name="skipPropeties">A list of names for properties not to check for equality</param>
    /// <returns></returns>
    public static bool PropertiesEquals<T>(this T first, T other, string[] skipPropeties=null) where T : class
    {
        var type = typeof (T);
        if(skipPropeties==null)
            skipPropeties=new string[0];
        if(skipPropeties.Except(type.GetProperties().Select(x=>x.Name)).Any())
            throw new ArgumentException("Type does not contain property to skip");
        var propertyInfos = type.GetProperties()
                                     .Except(type.GetProperties().Where(x=> skipPropeties.Contains( x.Name)));
        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            if (!Equals(propertyInfo.GetValue(first, null), 
                        propertyInfo.GetValue(other, null)))
                return false;
        }
        return true;
    }
