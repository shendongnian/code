        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlexcel;
            Excel.Workbook xlWorkBook;
            Excel.Sheets worksheets;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            //~~> Open a File
            xlWorkBook = xlexcel.Workbooks.Open("C:\\Sample.xlsx", 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //~~> Specify the sheets you want to copy
            String[] selectedSheets = { "a", "c", "d" };
            //~~> Set your worksheets
            worksheets = xlWorkBook.Worksheets;
            //~~>Copy it. This will create a new Excel file with selected sheets
            ((Excel.Sheets)worksheets.get_Item(selectedSheets)).Copy();
        }
