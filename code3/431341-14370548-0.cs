            int sheetIndex = 1; //PLEASE NOTE THIS LIB WORKS WITH NON-ZERO BASED INDEX
            string excelFilePath = "your_path/your_excel_file.xls";
            List<string> yourList = new List<string>();
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);            
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[sheetIndex];
            Microsoft.Office.Interop.Excel.Range rangeSelection = worksheet.Columns[1];
            foreach (Microsoft.Office.Interop.Excel.Range row in rangeSelection.Rows)
            {
                Microsoft.Office.Interop.Excel.Range cell = (Microsoft.Office.Interop.Excel.Range)row.Cells[1, 1];
                if (cell.Value2 != null)
                    list.Add(cell.Value2.ToString());
            }
