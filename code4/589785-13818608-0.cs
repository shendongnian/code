    public static string ConvertToString(this object obj)
    {
        StringBuilder sb = new StringBuilder();
        Type type = obj.GetType();
        sb.AppendFormat("for class {0}:", type.Name);
        sb.Append("{");
        foreach (PropertyInfo p in type.GetProperties())
        {
            if (!p.GetIndexParameters().Any())
                    sb.AppendFormat("\"{0}\"", p.GetValue(obj, null));
        }
        sb.Append("}");
        return sb.ToString();
    }
