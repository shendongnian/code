    public void Convert(String filesFolder)
    {
      files = Directory.GetFiles(filesFolder);
    
      var app = new Microsoft.Office.Interop.Excel.Application();
      var wb = app.Workbooks.Open(file);
      wb.SaveAs(Filename: file + "x", FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
      wb.Close();
      app.Quit();
    }
