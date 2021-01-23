    //hex encoding of the hash, in uppercase.
    public static string Sha1Hash (this string str)
    {
    	byte[] data = UTF8Encoding.UTF8.GetBytes (str);
    	data = data.Sha1Hash ();
    	return BitConverter.ToString (data).Replace ("-", "");
    }
    // Do the actual hashing
    public static byte[] Sha1Hash (this byte[] data)
    {
    	using (SHA1Managed sha1 = new SHA1Managed ()) {
    	return sha1.ComputeHash (data);
    }
