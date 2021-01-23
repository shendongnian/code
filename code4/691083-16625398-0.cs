    public WmlDocument GetProcessedTemplate(string templatePath, string insertKey)
    {
        WmlDocument templateDoc = new WmlDocument(templatePath);
    	using (MemoryStream mem = new MemoryStream())
        {
    		mem.Write(templateDoc.DocumentByteArray, 0, templateDoc.DocumentByteArray.Length);
    		using (WordprocessingDocument doc = WordprocessingDocument.Open([source], true))							
    		{
    			XDocument xDoc = doc.MainDocumentPart.GetXDocument();
    			XElement bookMarkPara = [get bookmarkPara to replace];
    			bookMarkPara.ReplaceWith(new XElement(PtOpenXml.Insert, new XAttribute("Id", insertKey)));
    			doc.MainDocumentPart.PutXDocument();
    		}
    		templateDoc.DocumentByteArray = mem.ToArray();
    	}
    	return templateDoc;
    }
