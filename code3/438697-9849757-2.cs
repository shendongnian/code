	    Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        Excel.Range rangeToHoldHyperlink;
        Excel.Range CellInstance;
        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Add(misValue);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        xlApp.DisplayAlerts = false;
        //Dummy initialisation to prevent errors.
        rangeToHoldHyperlink = xlWorkSheet.get_Range("A1", Type.Missing);
        CellInstance = xlWorkSheet.get_Range("A1", Type.Missing);
        
	    for (int i = 0; i < NumberOfCols; i++)
        {
	    	    for (int j = 0; j <= NumberOfRows; j++)
                {
                    xlWorkSheet.Cells[j + 1, i + 1] = DataToWrite[j][i];
                }
	     }
