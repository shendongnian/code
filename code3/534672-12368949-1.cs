        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range xlRange;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlWorkBook = xlexcel.Workbooks.Add();
            // Set Sheet 1 as the sheet you want to work with
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlRange = xlWorkSheet.get_Range("$7:$9,$12:$12,$14:$14", misValue);
            MessageBox.Show(xlRange.Address);
        }
