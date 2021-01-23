    Dictionary<string, byte[]> pdfByteList = new Dictionary<string, byte[]>();
    string pageName = "TestPage";
    string htmlToConvert = GetHTML(pageName); //Perform the Server.Execute() code here and return the HTML
    
    PdfConverter converter = new PdfConverter();
    byte[] pdfBytes = converter.GetPdfBytesFromHtmlString(htmlToConvert);
    pdfByteList.Add(pageName, pdfBytes);
    
    using (ZipFile zip = new ZipFile())
    {
    	int i = 0;
    	foreach(KeyValuePair<string,byte[]> kvp in pdfByteList)
    	{
    		zip.AddEntry(kvp.Key, kvp.Value);
    		i++;
    	}
    
    	Response.Clear();
    	Response.BufferOutput = true; // false = stream immediately
    	Response.ContentType = "application/zip";
    	Response.AddHeader("content-disposition", "attachment; filename=TheZipFile.zip");
    	zip.Save(Response.OutputStream);
    }
