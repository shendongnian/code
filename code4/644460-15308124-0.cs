    public List<string[]> ExtractGridData(DataGridView grid)
    {
        int numCols = grid.Columns.Count;
        List<string[]> list = new List<string[]>();
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.IsNewRow) // skip the new row
                continue;
            string[] cellsData = new string[numCols];
            foreach (DataGridViewCell cell in row.Cells)
                if (cell.Value != null)
                    cellsData[cell.ColumnIndex] = cell.Value.ToString();
            list.Add(cellsData);
        }
        return list;
    }
