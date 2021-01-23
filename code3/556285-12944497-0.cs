    using Excel = Microsoft.Office.Interop.Excel;
        private void TestButton_Click(object sender, RibbonControlEventArgs e)
        {
            var worksheet = (Excel.Worksheet) Globals.ThisAddIn.Application.ActiveSheet;
            var tables = worksheet.ListObjects;
            var table = tables.Item["Table1"]; // this is the line you are referring to
            
            //do something with table
        }
