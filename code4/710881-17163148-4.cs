    public static String GetPropertyValue(String objectName, String propertyName)
    {
        try
        {
            var o = Objects[objectName];
            return GetPropertyValue(o, propertyName)
        }
        catch (Exception)
        {
            return null;
        }
    }
