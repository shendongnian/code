        public void ReadAndWriteToExcel()
        {
            string myPath = @"C:\Excel.xls";
            FileInfo fi = new FileInfo(myPath);
            if (!fi.Exists)
            {
                Console.Out.WriteLine("file doesn't exists!");
            }
            else
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Open(myPath);
                Worksheet worksheet = workbook.ActiveSheet as Worksheet;
                // To write to excel
                Microsoft.Office.Interop.Excel.Range range = worksheet.Cells[1, 1] as Range;
                DateTime dt = dateTimePicker1.Value;
                range.NumberFormat = "dd/MMM/yyyy";
                range.Value2 = dt;
                // To read,
                var date = worksheet.Cells[1, 1].Value2;
                workbook.Save();
                workbook.Close();
            }
        }
