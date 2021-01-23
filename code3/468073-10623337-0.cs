	public byte[] ToByte (NSData data)
	{
		MemoryStream ms = new MemoryStream ();
		data.AsStream ().CopyTo (ms);
		return ms.ToArray ();
	}
	public string ToBase64String (NSData data)
	{
		return Convert.ToBase64String (ToByte (data));
	}
