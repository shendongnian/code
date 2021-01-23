                        Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[2];
                        Excel.Range excelRange = excelWorksheet.UsedRange;
                        int rowCount = excelRange.Rows.Count;
                        int colCount = excelRange.Columns.Count;
--------------------------------------------------------------------------
    string wwdEmpty = Convert.ToString(excelRange.Cells[5, 14].value2);
    // this is working code with NULL Excell cell 
