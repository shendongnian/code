        private void btnExcel_Click(object sender, EventArgs e)
        {
            string newDirectoryPath = ValidateDirectory();
            string newFilePath = Path.Combine(newDirectoryPath, "new.xls");
            
            //brand new temporary file
            string tempPath = System.IO.Path.GetTempFileName();
            //to manage de temp file life
            FileInfo tempFile = new FileInfo(tempPath);
            //copy the structure and data of the template .xls
            System.IO.File.WriteAllBytes(tempPath,Properties.Resources.SomeResource);
            Excel.Application xlApp;  
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(tempPath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //WorkTheExcelFile();
            tempFile.Delete();
            xlWorkBook.SaveAs(newFilePath);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            Process.Start(newFilePath + ".xlsx");
        }
