    using (MemoryStream ms = new MemoryStream(data))
    {
	    MemoryStream msInner = new MemoryStream();
        // Read past the first two bytes of the zlib header
        ms.Seek(2, SeekOrigin.Begin);
        using (DeflateStream z = new DeflateStream(ms, CompressionMode.Decompress))
        {
		    z.CopyTo(msInner);
