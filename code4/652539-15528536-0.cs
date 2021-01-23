    public string ClassToString(Object o)
    {
        Type type = o.GetType();
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in type.GetFields())
        {
            sb.Append(field.Name).AppendLine(": ");
            sb.AppendLine(field.GetValue(o).ToString());
        }
        foreach (PropertyInfo property in type.GetProperties())
        {
            sb.Append(property.Name).AppendLine(": ");
            sb.AppendLine(property.GetValue(o, null).ToString());
        }
        return sb.ToString();
    }
