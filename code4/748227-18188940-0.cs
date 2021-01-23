    public static string FormatNamed(this string formatString, object parameters)
    {
        var t = parameters.GetType();
        var tmpVal = formatString;
        foreach(var p in t.GetProperties())
        {
            tmpVal = tmpVal.Replace("{" + p.Name + "}", p.GetValue(parameters));
        }
        return tmpVal;
    }
