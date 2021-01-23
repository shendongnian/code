    public static bool Is<T>(this string input)
    {
        try
        {
            TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
        }
        catch
        {
            return false;
        }
    
        return true;
    }
