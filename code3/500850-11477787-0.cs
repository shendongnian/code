    private static void Excel_FromDataTable(DataTable dt)
        {
            // Global missing variable.
            object missing = System.Reflection.Missing.Value;
            // Creates an excel object, 
            Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            // Then a workbooks object,
            Excel.Workbooks workbooks = excel.Workbooks;
            // Then adds a workbook object,
            Excel.Workbook workbook = workbooks.Add(true);
            // Then adds a worksheet object,
            Excel.Worksheet activeSheet = workbook.ActiveSheet;
            // Then names the worksheet to what we need.
            activeSheet.Name = "scbyext";
            // Add column headings,
            int iCol = 0;
            // for each row of data,
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // Then add each row's cell data.
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    excel.Cells[iRow, iCol] = r[c.ColumnName];
                }
            }
            // Disable Excel prompts.
            excel.DisplayAlerts = false;
            // Save the workbook to the correct folder.
            workbook.SaveAs("C:\\Escaped\\Path",
            Excel.XlFileFormat.xlExcel8, missing, missing,
            false, false, Excel.XlSaveAsAccessMode.xlNoChange,
            missing, missing, missing, missing, missing);
            
            // Release the objects we made, in reverse order, to allow Excel to quit correctly.
            ReleaseObj(activeSheet);
            ReleaseObj(workbook);
            ReleaseObj(workbooks);
            excel.Quit();
            ReleaseObj(excel);
        }
