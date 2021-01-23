    Microsoft.Office.Tools.Excel.NamedRange myNamedRange = Globals.Sheet1.namedRange1;
    myNamedRange.PrintOutEx(
      1, 
      wb.Worksheets.Count,
      printerSettings.Copies,
      false, 
      printerSettings.PrinterName, 
      false, 
      printerSettings.Collate, 
      false
    );
