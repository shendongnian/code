    public static String Compress(String decompressed)
	{
		byte[] data = Encoding.UTF8.GetBytes(decompressed);
		using (var input = new MemoryStream(data))
		using (var output = new MemoryStream())
		{
			using (var gzip = new GZipStream(output, CompressionMode.Compress, true))
			{
				input.CopyTo(gzip);
			}
			return Convert.ToBase64String(output.ToArray());
		}
	}
	public static String Decompress(String compressed)
	{
		byte[] data = Convert.FromBase64String(compressed);
		using (MemoryStream input = new MemoryStream(data))
		using (GZipStream gzip = new GZipStream(input, CompressionMode.Decompress))
		using (MemoryStream output = new MemoryStream())
		{
			gzip.CopyTo(output);
			StringBuilder sb = new StringBuilder();
			return Encoding.UTF8.GetString(output.ToArray());
		}
	}
