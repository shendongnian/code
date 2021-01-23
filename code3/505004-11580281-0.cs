    public static int ToInt32(object value)
    {
        if (value == null)
        {
            return 0;
        }
        else
        {
            return ((IConvertible)value).ToInt32(null);
        }
    }
