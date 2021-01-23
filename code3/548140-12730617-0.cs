    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Open(@"\my_template.xlt");
    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[0];
    
	//Do stuff
	
    workbook.SaveAs("newfile.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8);
    workbook.Close(true);
    app.Quit();
