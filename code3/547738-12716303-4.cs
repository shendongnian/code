	private static Dictionary<string,MemoryStream> UnZipToMemory()
	{
		var result = new Dictionary<string,MemoryStream>();
		using (ZipFile zip = ZipFile.Read(LocalCatalogZip))
		{
			foreach (ZipEntry e in zip)
            {
                MemoryStream data = new MemoryStream();
                e.Extract(data);
                result.Add(e.FileName, data);
            }
	    }
		return result;
	}
