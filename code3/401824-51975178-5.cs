	public static void ExtractTarGz(string filename, string outputDir)
	{
		using (var stream = File.OpenRead(filename))
			ExtractTarGz(stream, outputDir);
	}
	public static void ExtractTarGz(Stream stream, string outputDir)
	{
		// A GZipStream is not seekable, so copy it first to a MemoryStream
		using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
		{
			const int chunk = 4096;
			using (var memStr = new MemoryStream())
			{
				int read;
				var buffer = new byte[chunk];
				do
				{
					read = gzip.Read(buffer, 0, chunk);
					memStr.Write(buffer, 0, read);
				} while (read == chunk);
				memStr.Seek(0, SeekOrigin.Begin);
				ExtractTar(memStr, outputDir);
			}
		}
	}
	public static void ExtractTar(string filename, string outputDir)
	{
		using (var stream = File.OpenRead(filename))
			ExtractTar(stream, outputDir);
	}
