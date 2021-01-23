    public static void makeWordsHyperlinks(string file, string outputFile)
    {
    	using (PdfDocument pdf = new PdfDocument(file))
    	{
    		foreach (PdfPage page in pdf.Pages)
    		{
    			PdfCollection<PdfTextData> words = page.GetWords();
    			foreach (PdfTextData word in words)
    			{
    				// let's take anything starting from L
    				// you can discriminate words as you like, of course
    				if (word.Text.StartsWith("L", StringComparison.InvariantCultureIgnoreCase))
    				{
    					// build lookup query. you can use any url, of course
    					string lookupUrl = string.Format(@"https://www.google.ru/#q={0}", word.Text);
    
    					// let's draw rectangle around word.
    					// just to make links easier to find
    					page.Canvas.DrawRectangle(word.Bounds, PdfDrawMode.Stroke);
    
    					page.AddHyperlink(word.Bounds, new Uri(lookupUrl));
    				}
    			}
    		}
    
    		pdf.Save(outputFile);
    	}
    }
