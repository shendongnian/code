    public static string Protect(string text, string purpose)
	{
		if (string.IsNullOrEmpty(text))
			return null;
		
		byte[] stream = Encoding.UTF8.GetBytes(text);
		byte[] encodedValue = MachineKey.Protect(stream, purpose);
		return HttpServerUtility.UrlTokenEncode(encodedValue);
	}
	public static string Unprotect(string text, string purpose)
	{
		if (string.IsNullOrEmpty(text))
			return null;
		byte[] stream = HttpServerUtility.UrlTokenDecode(text);
		byte[] decodedValue = MachineKey.Unprotect(stream, purpose);
		return Encoding.UTF8.GetString(decodedValue);
	}
