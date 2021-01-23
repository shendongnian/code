    public static string ValuesAsCAML(IEnumerable<string> values, string type)
    {
        StringBuilder output = new StringBuilder();
        foreach (string value in values)
        {
            output.AppendFormat("<Value Type=`{0}`>{1}</Value>", type, value);
        }
    
        return output.ToString();
    }
