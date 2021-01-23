        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            
            //Convert the XML into Dataset
            ds.ReadXml(@"E:\movies.xml");
            //Retrieve the table fron Dataset
            //DataTable dt = ds.Tables[0];
            // Create an Excel object
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Create workbook object
            string str = @"E:\test.xlsx";
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(Filename: str);
            foreach (DataTable tab in ds.Tables)
            {
                FromDataTableToExcel(tab,excel,workbook);
            }
            //Save the workbook
            workbook.Save();
            //Close the Workbook
            workbook.Close();
            // Finally Quit the Application
            ((Microsoft.Office.Interop.Excel._Application)excel).Quit();
            
        }
        static void FromDataTableToExcel(DataTable dt, Microsoft.Office.Interop.Excel.Application excel, Microsoft.Office.Interop.Excel.Workbook workbook)
        { 
            //Create worksheet object
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
            // Column Headings
            int iColumn = worksheet.UsedRange.Columns.Count-1;
            int iColumn1 = iColumn;
            int iColumn2 = iColumn;
            foreach (DataColumn c in dt.Columns)
            {
                iColumn++;
                excel.Cells[1, iColumn] = c.ColumnName;
            }
            // Row Data
            int iRow = 0;
            foreach (DataRow dr in dt.Rows)
            {
                iRow++;
                // Row's Cell Data                
                foreach (DataColumn c in dt.Columns)
                {
                    iColumn1++;
                    excel.Cells[iRow + 1, iColumn1] = dr[c.ColumnName];
                }
                iColumn1 = iColumn2;
            }
            ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
        }
