    public static bool Is<T>(this string s)
    {
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
		
		try
		{	
			object val = converter.ConvertFromInvariantString(s);
			return true;
		}
		catch
		{
			return false;
		}
    }
