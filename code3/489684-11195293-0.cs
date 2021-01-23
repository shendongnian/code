    using Word = Microsoft.Office.Interop.Word;
    ...
    
    string workbookPath = @"C:\temp\example.xlsx";
    Excel.Workbook wb = Globals.ThisAddIn.Application.Workbooks.Add(workbookPath);
    Excel.Worksheet ws = wb.Worksheets[1];
    Word.Application wdApp = new Word.Application();
    Word.Document wdDoc = wdApp.Documents.Add();
    ws.Range["A1:D4"].Copy();
    wdDoc.ActiveWindow.Selection.PasteExcelTable(false, false, false);
