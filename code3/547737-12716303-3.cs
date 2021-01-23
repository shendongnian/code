	private static MemoryStream UnZipCatalog()
	{
		MemoryStream data = new MemoryStream();
		using (ZipFile zip = ZipFile.Read(LocalCatalogZip))
		{
			zip["ListingExport.txt"].Extract(data);
		}
		data.Seek(0, SeekOrigin.Begin);
		return data;
	}
