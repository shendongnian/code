	public long Size(FileItem[] files)
	{
		using (var ms = new PositionWrapperStream(Stream.Null))
		{
			using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
			{
				foreach (var file in files)
				{
					var entry = archive.CreateEntry(file.Name, CompressionLevel.NoCompression);
					using (var zipStream = entry.Open())
					{
						WriteZero(zipStream, file.Length);//the actual content does not matter
					}
				}
			}
			return ms.Position;
		}
	}
	private void WriteZero(Stream target, long count)
	{
		byte[] buffer = new byte[1024];
		while (count > 0)
		{
			target.Write(buffer, 0, (int) Math.Min(buffer.Length, count));
			count -= buffer.Length;
		}
	}
