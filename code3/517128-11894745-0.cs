        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("Sheet1111");
            this.comboBox1.Items.Add("Sheet2222");
            this.comboBox1.Items.Add("Sheet3333");
        }
       private void btnOPen_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            //~~> Open a File
            xlWorkBook = xlexcel.Workbooks.Open("C:\\sample.xlsx", 0, true, 5, "", "", true,
            Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            // Set Sheet 1 as the sheet you want to work with
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            string WsName = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            xlWorkSheet.Name = WsName;
           //
           //~~> Rest of code
           //
        }
