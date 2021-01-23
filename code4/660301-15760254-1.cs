        public void insertaRango(Worksheet sheet, List<CellValue> values)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            WorksheetCell cell;
            foreach (var value in values)
            {
                cell = row.Cells.Add();
                cell.Data.Text = value.Value.ToString();
                cell.MergeAcross = value.ColumnMerge;
                cell.StyleID = value.StyleID;
                cell.Data.Type = value.DataType;
            }
        }
