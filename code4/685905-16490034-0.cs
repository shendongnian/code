        Stream stream = new MemoryStream(file); // file as your byte[]
    	using (ZipArchive archive = new ZipArchive(stream))
	    {
	    	foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (entry.FullName.EndsWith(".tsv", StringComparison.OrdinalIgnoreCase))
				{
					using (stream = entry.Open())
					using (var reader = new StreamReader(stream)) {
							string output = reader.ReadToEnd();
				}
			}		
        }
