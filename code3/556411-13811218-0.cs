	public static string doWeirdMapping(string arg)
	{
		Encoding w1252 = Encoding.GetEncoding(1252);
		return Encoding.UTF8.GetString(w1252.GetBytes(arg));
	}
	
