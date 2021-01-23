	public FileStreamResult DownloadPDF()
	{
		MemoryStream workStream = new MemoryStream();
		ZipFile zip = new ZipFile();
		foreach(Bla bla in Blas)
		{
			MemoryStream pdfStream = new MemoryStream();
			Document document = new Document();
			PdfWriter.GetInstance(document, pdfStream).CloseStream = false;
			document.Open();
			// PDF Content
			document.Close();
			byte[] pdfByteInfo = pdfStream.ToArray();
			zip.AddEntry(bla.filename + ".pdf", pdfByteInfo);
			pdfStream.Close();
		}
		zip.Save(workStream);
		workStream.Position = 0;
		FileStreamResult fileResult = new FileStreamResult(workStream, System.Net.Mime.MediaTypeNames.Application.Zip);
		fileResult.FileDownloadName = "MultiplePDFs.zip";
		return fileResult;
	}
