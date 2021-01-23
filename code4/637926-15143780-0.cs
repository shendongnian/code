    public Microsoft.Office.Interop.Excel.Workbook excelWorkbook { get; set; }
    void ExcelToPdf(string convertFilePath, string documentUncPath)
    {
        Microsoft.Office.Interop.Excel.Application appWord = new Microsoft.Office.Interop.Excel.Application();
        excelWorkbook = appWord.Workbooks.Open(documentUncPath); // WAS DocumentUNCPath.Text
        excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, convertFilePath);
        excelWorkbook.Close();
        appWord.Quit();
    }
