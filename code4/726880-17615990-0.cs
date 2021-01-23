    if (dt.Columns.Count == 0)
    {
        int empty = 0;
        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
        {
            ICell cell = row.GetCell(j);
            if (cell == null)
            {
                dt.Columns.Add(String.Format("emptyColumnName_{0}", empty++));
            }
            else
            {
                dt.Columns.Add(row.GetCell(j).ToString());
            }
        }
        continue;
    }
