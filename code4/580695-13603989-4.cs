    using (SpreadsheetDocument xl = SpreadsheetDocument.Open(@"C:/Users/jeeva/sample-excel-files/SampleExcel.xlsx", true))
    {             
    	WorkbookPart wbp = xl.WorkbookPart;
    
    	// Input for this program
    	string name = "_xlnm.Print_Titles";
    	string comment = "this is Print Titles for Sheet1";
    	string text = "Sheet1!$1:$1";
    
    	if (wbp.Workbook.DefinedNames == null) 
    	{
    		wbp.Workbook.DefinedNames = new DefinedNames();
    	}                
    
    	bool bFound = false;
    	foreach (DefinedName d in wbp.Workbook.DefinedNames)
    	{
    		// if found overwrite existing defined name
    		if (d.Name.Value.Equals(name, StringComparison.InvariantCultureIgnoreCase)) 
    		{
    			bFound = true;
    			d.Text = text;
    			d.Comment = comment;
    			break;
    		}
    	}
    
    	if (!bFound) // if not found, add one
    	{
    		wbp.Workbook.DefinedNames.Append(getDefinedName(name, text, comment));
    	}
                    
    	wbp.Workbook.Save();
    	xl.Close();
    }
    
    private static DefinedName getDefinedName(string Name, string Text, string Comment)
    {
    	DefinedName dn = new DefinedName();
    	dn.Text = Text;
    	dn.Name = Name;
    	dn.Comment = Comment;
    	dn.LocalSheetId = (UInt32Value)1U;
    	dn.Xlm = true; // since its a special schema name
    }
