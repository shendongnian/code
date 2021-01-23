    public static void FitAndSaveToExcel(FileInfo excelFile, string sheetName)
    {
      ExcelPackage pack = new ExcelPackage();
      ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
      ws.Cells[1, 1].Value = "Some Long text that needs fitting!";
      ws.Cells[1, 2].Value = "Short one";
      ws.Column(1).AutoFit();
      pack.SaveAs(excelFile);
    }
