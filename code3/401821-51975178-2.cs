	public static void ExtractTar(Stream stream, string outputDir)
	{
		var buffer = new byte[100];
		while (true)
		{
			stream.Read(buffer, 0, 100);
			var name = Encoding.ASCII.GetString(buffer).Trim('\0');
			if (String.IsNullOrWhiteSpace(name))
				break;
			stream.Seek(24, SeekOrigin.Current);
			stream.Read(buffer, 0, 12);
			var size = Convert.ToInt64(Encoding.ASCII.GetString(buffer, 0, 12).Trim(), 8);
			stream.Seek(376L, SeekOrigin.Current);
			var output = Path.Join(outputDir, name);
			if (!Directory.Exists(Path.GetDirectoryName(output)))
				Directory.CreateDirectory(Path.GetDirectoryName(output));
			using (var str = File.Open(output, FileMode.OpenOrCreate, FileAccess.Write))
			{
				var buf = new byte[size];
				stream.Read(buf, 0, buf.Length);
				str.Write(buf, 0, buf.Length);
			}
			var pos = stream.Position;
			var offset = 512 - (pos  % 512);
			if (offset == 512)
				offset = 0;
			stream.Seek(offset, SeekOrigin.Current);
		}
	}
