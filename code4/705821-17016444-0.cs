           const string MyFileName = "myExcelFile.xls";
            
            string execPath =Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var filePath = Path.Combine(execPath, MyFileName);
            Microsoft.Office.Interop.Excel.Application app = new Application();
            Microsoft.Office.Interop.Excel.Workbook book = app.Workbooks.Open(filePath);
            book.SaveAs(@"C:\Users\Desktop\NewExcel.xlsx");
            book.Close();
