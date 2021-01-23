    public DataTable GetWorkSheet(int workSheetID)
        {
            string pathOfExcelFile = fileFullName;
            DataTable dt = new DataTable();
            try
            {
                excel.Application excelApp = new excel.Application();
                excelApp.DisplayAlerts = false; //Don't want Excel to display error messageboxes
                excel.Workbook workbook = excelApp.Workbooks.Open(pathOfExcelFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //This opens the file
                excel.Worksheet sheet = (excel.Worksheet)workbook.Sheets.get_Item(workSheetID); //Get the first sheet in the file
                int lastRow = sheet.Cells.SpecialCells(excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                int lastColumn = sheet.Cells.SpecialCells(excel.XlCellType.xlCellTypeLastCell, Type.Missing).Column;
                excel.Range oRange = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[lastRow, lastColumn]);//("A1",lastColumnIndex + lastRow.ToString());
                oRange.EntireColumn.AutoFit();
                for (int i = 0; i < oRange.Columns.Count; i++)
                {
                    dt.Columns.Add("a" + i.ToString());
                }
                object[,] cellValues = (object[,])oRange.Value2;
                object[] values = new object[lastColumn];
                for (int i = 1; i <= lastRow; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        values[j] = cellValues[i, j + 1];
                    }
                    dt.Rows.Add(values);
                }
                
                workbook.Close(false, Type.Missing, Type.Missing);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dt;
        }
