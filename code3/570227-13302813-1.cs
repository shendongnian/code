	public static void Merge(string[] sourceFiles, string destinationFile)
	{
		try
		{
			int f = 0;
			// we create a reader for a certain document
			PdfReader reader = new PdfReader(sourceFiles[f]);
			// we retrieve the total number of pages
			int n = reader.NumberOfPages;
			//Debug.WriteLine("There are " + n + " pages in the original file.");
			// step 1: creation of a document-object
			Document document = new Document(reader.GetPageSizeWithRotation(1));
			// step 2: we create a writer that listens to the document
			PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
			// step 3: we open the document
			document.Open();
			PdfContentByte cb = writer.DirectContent;
			PdfImportedPage page;
			int rotation;
			// step 4: we add content
			while (f < sourceFiles.Length)
			{
				int i = 0;
				while (i < n)
				{
					i++;
					document.SetPageSize(reader.GetPageSizeWithRotation(i));
					document.NewPage();
					page = writer.GetImportedPage(reader, i);
					rotation = reader.GetPageRotation(i);
					if (rotation == 90 || rotation == 270)
					{
						cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
					}
					else
					{
						cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
					}
					//Debug.WriteLine("Processed page " + i);
				}
				f++;
				if (f < sourceFiles.Length)
				{
					reader = new PdfReader(sourceFiles[f]);
					// we retrieve the total number of pages
					n = reader.NumberOfPages;
					//Debug.WriteLine("There are " + n + " pages in the original file.");
				}
			}
			// step 5: we close the document
			document.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
