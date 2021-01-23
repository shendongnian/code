     string path = @"C:\temp\test.xls";
       ApplicationClass excelApllication = null;
       Workbook excelWorkBook = null;
       Worksheet excelWorkSheet = null;
      
       excelApllication = new ApplicationClass();
       System.Threading.Thread.Sleep(2000);
       excelWorkBook = excelApllication.Workbooks.Add();
       excelWorkSheet = (Worksheet)excelWorkBook.Worksheets.get_Item(1);
       // Attention: 1 indexed cells, [Row, Col]
       excelWorkSheet.Cells[1, 1] = "Column A, Row 1";
       excelWorkSheet.Cells[2, 5] = "Column E, Row 2";
       excelWorkSheet.Cells[3, 3] = "Column C, Row 3";
      
       excelWorkBook.SaveAs(path, XlFileFormat.xlWorkbookNormal);
      
       excelWorkBook.Close();
       excelApllication.Quit();
      
       Marshal.FinalReleaseComObject(excelWorkSheet);
       Marshal.FinalReleaseComObject(excelWorkBook);
       Marshal.FinalReleaseComObject(excelApllication);
       excelApllication = null;
       excelWorkSheet = null;
       Process.Start(path);
