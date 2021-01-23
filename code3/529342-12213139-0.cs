    public static bool Is<T>(this string s)
    {
    		TypeConverter converter = TypeDescriptor.GetConverter(T);
    		object val = converter.ConvertFromInvariantString(s);
    		return (T)val;
    }
