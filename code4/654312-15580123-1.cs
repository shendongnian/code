	System.Security.Cryptography.SHA1 c = System.Security.Cryptography.SHA1.Create();
	byte[] b = c.ComputeHash(Encoding.UTF8.GetBytes("google.com"));
	long value = BitConverter.ToInt64(b, 12);
	value = IPAddress.HostToNetworkOrder(value);
	Debug.WriteLine(value);
	// writes 2172193747348806725
