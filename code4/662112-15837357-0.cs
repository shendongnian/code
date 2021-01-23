    for (var i = 0; i < GoodDT.Rows.Count; i++)
    {
        for (var x = 0; x < GoodDT.Columns.Count; x++)
        {
            if (BadDT.Columns[x].ColumnName != "skip1" && BadDT.Columns[x].ColumnName != "skip2")
            {
                BadDT.Rows[i][x] = GoodDT.Rows[i][x];
            }
        }
    }
