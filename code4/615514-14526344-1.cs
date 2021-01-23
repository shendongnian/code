       public static string ObjectToCsv<T>(T myObject)
    {
        var objectString = "";
        foreach (FieldInfo field in typeof(T).GetFields())
        {
            objectString += field.GetValue(myObject).ToString() + ',';
        }
        return objectString.TrimEnd(',');
    }
