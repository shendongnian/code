    List<VbaProjectPart> newParts = new List<VbaProjectPart>();
    using (var originalDocument = SpreadsheetDocument.Open("file1.xlsm"), false))
    {
    	newParts = originalDocument.WorkbookPart.GetPartsOfType<VbaProjectPart>().ToList();
    
    	using (var document = SpreadsheetDocument.Open("file2.xlsm", true))
    	{
    		document.WorkbookPart.DeleteParts(document.WorkbookPart.GetPartsOfType<VbaProjectPart>());
    
    		foreach (var part in newParts)
    		{
    			VbaProjectPart vbaProjectPart = document.WorkbookPart.AddNewPart<VbaProjectPart>();
    			using (Stream data = part.GetStream())
    			{
    				vbaProjectPart.FeedData(data);
    			}                    
    		}
    		
    		//Note this prevents the duplicate worksheet issue
    		spreadsheetDocument.WorkbookPart.Workbook.WorkbookProperties.CodeName = "ThisWorkbook";
    	}
    }
