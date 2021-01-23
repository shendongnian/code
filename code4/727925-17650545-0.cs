            DataSet ds = new DataSet();
            
            //Convert the XML into Dataset
            ds.ReadXml(@"E:\movie.xml");
            //Retrieve the table fron Dataset
            DataTable dt = ds.Tables[0];
            
            // Create an Excel object
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Create workbook object
            string str = @"E:\test.xlsx";
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(Filename: str);
            //Create worksheet object
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
            // Column Headings
            int iColumn = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iColumn++;
                excel.Cells[1, iColumn] = c.ColumnName;
            }
            // Row Data
            int iRow = worksheet.UsedRange.Rows.Count - 1;
            
            foreach (DataRow dr in dt.Rows)
            {
                iRow++;
                // Row's Cell Data
                iColumn = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iColumn++;
                    excel.Cells[iRow + 1, iColumn] = dr[c.ColumnName];
                }
            }
            ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
            //Save the workbook
            workbook.Save();
            //Close the Workbook
            workbook.Close();
            // Finally Quit the Application
            ((Microsoft.Office.Interop.Excel._Application)excel).Quit();
