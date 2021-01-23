    string Format(object obj)
    {
        Type type = obj.GetType();
        foreach (PropertyInfo prop in type.GetProperties())
        {
            result += prop.Name + " = " + prop.GetValue(obj, null) + "\n";
        }
        foreach (FieldInfo field in type.GetFields())
        {
            result += field.Name + " = " + field.GetValue(obj) + "\n";
        }
        return result;
    }
