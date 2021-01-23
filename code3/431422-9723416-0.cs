    // OPEN EXCEL and WORKSHEET   
    
     xlApp = new Microsoft.Office.Interop.Excel.Application();
     xlWorkBook = xlApp.Workbooks.Open(@"C:\TEST.xlsx", 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
     xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Sheets[1];
    
    // F column index starting, A == 1
    int lastColumnIndex = 6; 
    
    // read each cell including 'F1' and add it to the richTextBox (it is my placeholder in test project)
    for (int i = 1; i <= lastColumnIndex; i++)
    {
    	richTextBox1.AppendText(Convert.ToString(((Range)xlWorkSheet.Cells[1, i]).Value2));
    }
    
    // read and save the value of 'F1' to a variable - 2nd read of the same cell can be avoided, though
    int extraColumnsToRead = Convert.ToInt32(((Range)xlWorkSheet.Cells[1, lastColumnIndex]).Value2) * 4;
    
    // (value(F1) * 4) cells will be loaded and added to my RichTextBox.
    if (extraColumnsToRead > 0)
    	for (int i = lastColumnIndex + 1; i <= lastColumnIndex + extraColumnsToRead; i++)
    	{
    		richTextBox1.AppendText(Convert.ToString(((Range)xlWorkSheet.Cells[1, i]).Value2));
    	}  
