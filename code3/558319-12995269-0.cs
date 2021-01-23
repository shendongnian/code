    public static string Serialize(object o)
	{
    	using (var s = new FileStream())
		{
			_binaryFormatter.Serialize(s, o);
		}
	}
