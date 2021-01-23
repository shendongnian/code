    protected void insertTextAt(string bookmarkName, string text,
    			bool useDefaults = true, string fontName = "Arial", 
    			int fontSize = 11, int bold = 0,bool newLine = true)
    		{
    			try
    			{
    				Object oBookMarkName = bookmarkName;
    				WordInterop.Range wRng =
    					this.wDoc.Bookmarks.get_Item(ref oBookMarkName).Range;
    				wRng.Text = text;
    				if (!useDefaults)
    				{
    					wRng.Font.Bold = bold;
    					wRng.Font.Name = fontName;
    					wRng.Font.Size = fontSize;
    				}
    				if (newLine)
    				{
    					wRng.Text += "\r\n";
    				}
    				wRng.Font.Bold = 0;
    			}
    			catch (Exception e)
    			{
    				String exceptionString = String.Format("Bookmark {0} could not"
    				+" be found in template {1}",bookmarkName,this.template);
    				throw new Exception(exceptionString,e);
    			}
    
    		}
