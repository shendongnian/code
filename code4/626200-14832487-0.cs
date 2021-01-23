    using (MemoryStream ms = new MemoryStream())
    {
    	Document doc = new Document(PageSize.A4, 50, 50, 15, 15);
    
    	PdfWriter writer = PdfWriter.GetInstance(doc, ms);
    
    	using (var rdr = new PdfReader(filePath))
    	{
    		PdfImportedPage page;
    		
    		for(int i = 1; i <= rdr.PageCount; i++)
    		{
    			page = writer.GetImportedPage(templateReader, i)
    			
    			writer.DirectContent.AddTemplate(page, 0, 0);
    			
    			doc.NewPage();
    		}
    	}
    }
