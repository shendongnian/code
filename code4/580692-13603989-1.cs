    using (SpreadsheetDocument xl = SpreadsheetDocument.Open("C:\\" + filename, true))
    {
    	var wbp = xl.WorkbookPart;
    	
    	var definedNames = wbp.Workbook.Descendants<DefinedNames>().FirstOrDefault();
    	DefinedName printTitles = new DefinedName() { Name = "_xlnm.Print_Titles", LocalSheetId = (UInt32Value)0U };
    	printTitles.Text = "alpha_sort_nc!$A$1:$F$1";	
    	if(definedNames == null) 
    	{
    		DefinedNames wbpDefinedNames = new DefinedNames();
    		wbpDefinedNames.Append(printTitles);
    		wbp.Workbook.Append(wbpDefinedNames);
    	}
    	else
    	{
    		definedNames.Append(printTitles);
    	}
    	
    	wbp.Workbook.Save();
    	xl.Close();
    }
