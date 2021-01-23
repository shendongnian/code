    public static void combineDocumentsWithBookmarks()
    {
    	string[] names = new string[] { "first.pdf", "second.pdf", "third.pdf" };
    
    	using (PdfDocument pdf = new PdfDocument())
    	{
    		int targetPageIndex = 0;
    		for (int i = 0; i < names.Length; i++)
    		{
    			string currentName = names[i];
    			
    			if (i == 0)
    				pdf.Open(currentName);
    			else
    				pdf.Append(currentName);
    
    			pdf.OutlineRoot.AddChild(currentName, targetPageIndex);
    			targetPageIndex = pdf.PageCount;
    		}
    
    		// setting PageMode will cause PDF viewer to display
    		// bookmarks pane when document is open
    		pdf.PageMode = PdfPageMode.UseOutlines;
    		pdf.Save("output.pdf");
    	}
    }
