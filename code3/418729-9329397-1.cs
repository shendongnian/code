    var dt = proxy.GetQuarterTargetAchievement();
    
    int
        column = 0,
        row = 0;
    foreach (DataColumn col in dt.Columns)
    {
        this.Application.Cells[1, ++column] = col.ColumnName;
    }
    
    foreach (DataRow r in dt.Rows)
    {
        row++;
        column = 0;
        foreach (DataColumn c in dt.Columns)
        {
            this.Application.Cells[row + 1, ++column] = r[c.ColumnName];
        }
    }
