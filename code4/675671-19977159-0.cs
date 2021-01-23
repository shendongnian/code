    private void WriteColumnHeaders(DataColumnCollection columnCollection, int row, int column)
        {
            // row represent particular row you want to bold its content.
            for (i = 0; i < columnCollection.Count; i++)
            {
                DataColumn col = columnCollection[i];
                xlWorkSheet.Cells[row, column + i + 1] = col.Caption;
                // Some Font Styles
                xlWorkSheet.Cells[row, column + i + 1].Style.Font.Bold = true;
                xlWorkSheet.Cells[row, column + i + 1].Interior.Color = Color.FromArgb(192, 192, 192);
                //xlWorkSheet.Columns[i + 1].ColumnWidth = xlWorkSheet.Columns[i+1].ColumnWidth + 10;
            }
        }
