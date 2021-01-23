	public static void insertVbaPart()using(SpreadsheetDocument ssDoc = SpreadsheetDocument.Open("file1.xlsm", false))
	{
		{
			WorkbookPart wbPart = ssDoc.WorkbookPart;
			MemoryStream ms;
			CopyStream(ssDoc.WorkbookPart.VbaProjectPart.GetStream(), ms);
	
			using(SpreadsheetDocument ssDoc2 = SpreadsheetDocument.Open("file2.xlsm", true))
			{
				Stream stream = ssDoc2.WorkbookPart.VbaProjectPart.GetStream();
				ms.WriteTo(stream);
			}
		}
	}
	public static void CopyStream(Stream input, Stream output)
	{
		byte[] buffer = new byte[short.MaxValue + 1];
		while (true)
		{
			int read = input.Read(buffer, 0, buffer.Length);
			if (read <= 0)
				return;
			output.Write(buffer, 0, read);
		}
	}
