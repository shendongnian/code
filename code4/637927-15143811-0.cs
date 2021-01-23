    namespace ClassLibrary1
    {
        public class Class1
        {
            public Microsoft.Office.Interop.Excel.Workbook excelWorkbook { get; set; }
            void ExcelToPdf(string convertFilePath)
            {
                Microsoft.Office.Interop.Excel.Application appWord = new Microsoft.Office.Interop.Excel.Application();
                excelWorkbook = appWord.Workbooks.Open(DocumentUNCPath.Text);
    
                excelWorkbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, convertFilePath);
                excelWorkbook.Close();
                appWord.Quit();
            }
        }
    }
