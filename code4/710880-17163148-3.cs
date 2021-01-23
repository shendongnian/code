    public static String GetPropertyValue(object o, String property)
    {
        try
        {
            return o.GetType().GetProperty(property).GetValue(o, null).ToString();
        }
        catch(Exception)
        {
            return null;
        }
    }
