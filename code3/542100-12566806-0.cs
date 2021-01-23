    using Excel = Microsoft.Office.Interop.Excel
    Excel.Application application = new Excel.Application();
    Excel.Workbook workbook = application.Workbooks.Add();
    Excel.Worksheet worksheet = workbook.Sheets[1];
    
    application.ActivePrinter = "Printer One";
    worksheet.PrintPreview();
