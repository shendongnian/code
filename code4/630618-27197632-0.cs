	using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MemoryMappedName))
	{
		using (MemoryMappedViewStream stream = mmf.CreateViewStream())
		{
			using (MemoryStream memStream = new MemoryStream())
			{
				stream.CopyTo(memStream);
				return memStream.ToArray();
			}
		}
	}
