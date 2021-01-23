    public static void SaveFile(BusinessObject document)
    {
        Type boType = document.GetType();
        PropertyInfo[] propertyInfo = boType.GetProperties();
        foreach (PropertyInfo item in propertyInfo)
        {
            Type xy = item.PropertyType;
            if (String.Equals(item.Name, "Content") &&
                (item.PropertyType == typeof(Byte[])))
            {
                Byte[] content = item.GetValue(document, null) as Byte[];
            }
        }
    }
