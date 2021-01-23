    _savePath = sfd.FileName;
    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    MessageBox.Show("GOOD2");
    excelApp.SheetsInNewWorkbook = 1;      
    try
    {
       // Must be surrounded by try catch to work.
       excelApp.Visible = true;
    }
    catch (Exception e)
    {
        Console.WriteLine("-------Error hiding the application-------");
        Console.WriteLine("Occured error might be: " + e.StackTrace);
    } 
    Microsoft.Office.Interop.Excel.Workbook workbook
    workbook = excelApp.Workbooks.Open("your excel file", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); // if working with another excel
    excelApp.Workbooks.Add();
    MessageBox.Show("GOOD3");
    Excel.Worksheet sheetC = excelApp.Sheets.get_Item(1);   
    sheetC.Name = "name-of-sheet";
    workbook.SaveCopyAs(_savePath); // SaveAs should work actually.
    workbook.Close();
    excelApp.Quit(); 
