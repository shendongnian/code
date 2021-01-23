    xlApp.DisplayAlerts = false;
    for (int i = xlApp.ActiveWorkbook.Worksheets.Count; i > 0 ; i--)
    {
    	Worksheet wkSheet = (Worksheet)xlApp.ActiveWorkbook.Worksheets[i];
    	if (wkSheet.Name == "NameOfSheetToDelete")
    	{
    		wkSheet.Delete();
    		
    	}
    }
    xlApp.DisplayAlerts = true;
