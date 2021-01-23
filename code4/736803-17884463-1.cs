    Excel.Application xlsApp = new Excel.Application();
    Excel.Workbook workbook;
    workbook = xlsApp.Workbooks.Open(configuration.XLSExportedFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    foreach (Excel.Worksheet sheet in workbook.Sheets)
    {
          workbook.Activate();
          sheet.Activate();
    }
