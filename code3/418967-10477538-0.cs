    Microsoft.Office.Interop.Excel.Range excelRange = wWorksheet.UsedRange;
    TabPage wTabPage = new TabPage(wWorksheet.Name.ToString());
    DataGridView wDGV = new DataGridView();
    wDGV.Dock = DockStyle.Fill;
    wTabPage.Controls.Add(wDGV);
    Sheets_TabControl.TabPages.Add(wTabPage);
    DataTable dt = new DataTable();
    DataRow wNewRow = null;
    // New code to create DataTable columns
    for (int i = 1; i <= excelRange.Columns.Count; i++)
    {
        // If the current column of cells does not contain any data, then don't add a column to the datatable
        if (xlSpreadsheet.App.WorksheetFunction.CountA(excelRange.Cells[Missing.Value, i]) != 0)
        {
            dt.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
        }
    }
    string wValue = string.Empty;
    Microsoft.Office.Interop.Excel.Range wRange = null;
    for (int wRowIndex = 1; wRowIndex <= excelRange.Rows.Count; wRowIndex++)
    {
        wNewRow = dt.NewRow();
        foreach (DataColumn wColumn in dt.Columns)
        {
            // Parse the column number we stored earlier as the column name
            int colNumber = 0;
            if (int.TryParse(wColumn.ColumnName, out colNumber))
            {
                // We use the parsed column number to index the column in the Excel range
                wRange = excelRange.Cells[wRowIndex, colNumber];
                if (wRange != null)
                {
                    if (wRange.Value2 != null)
                    {
                        wValue = wRange.Value2.ToString();
                        if (!string.IsNullOrEmpty(wValue))
                        {
                            wNewRow.SetField(wColumn, wValue);
                        }
                    }
                }
            }
        }
        dt.Rows.Add(wNewRow)
    }
    wDGV.DataSource = dt;
