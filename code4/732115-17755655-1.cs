        byte[] b;
	using (FileStream f = new FileStream("filename", FileMode.Open))
	{
	    b = new byte[f.Length];
	    f.Read(b, 0, (int)f.Length);
	}
    using (FileStream f2 = new FileStream(fileName, FileMode.Create))
	using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
	{
	    gz.Write(b, 0, b.Length);
	}
