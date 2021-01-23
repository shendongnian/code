    public static T FromString<T>(string value)
	{
		var result = default(T);
		if (value != null)
		{
			try {result = (T)Convert.ChangeType(value, typeof(T));  } catch {}
		}
		return result;
	}
