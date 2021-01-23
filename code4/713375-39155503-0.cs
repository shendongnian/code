    private  void downloadFile(EntityXML xml) {
	string nameDownloadXml = "File_1.xml";
	string nameDownloadZip = "File_1.zip";
	var serializer = new XmlSerializer(typeof(EntityXML));
	Response.Clear();
	Response.ClearContent();
	Response.ClearHeaders();
	Response.AddHeader("content-disposition", "attachment;filename=" + nameDownloadZip);
	using (var memoryStream = new MemoryStream())
	{
		using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
		{
			var demoFile = archive.CreateEntry(nameDownloadXml);
			using (var entryStream = demoFile.Open())
			using (StreamWriter writer = new StreamWriter(entryStream, System.Text.Encoding.UTF8))
			{
				serializer.Serialize(writer, xml);
			}
		}
		using (var fileStream = Response.OutputStream)
		{
			memoryStream.Seek(0, SeekOrigin.Begin);
			memoryStream.CopyTo(fileStream);
		}
	}
	Response.End();
}
