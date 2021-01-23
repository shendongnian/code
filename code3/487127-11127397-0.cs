    for (int i = 1; i <= range.Columns.Count; i++)
    {
         // Note: Add using directive for Microsoft.Office.Interop.Excel
         Range range = (Range) workSheet.Cells[1, i];
         string value = Convert.ToString(range.Value2);
         excel_Holding_Table.Columns.Add(value);
    }
