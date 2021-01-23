    for (int j = 0; j < Temp.Columns.Count; j++ )
    {
        if(!excelTb2.Columns.Contains(Temp.Columns[j].ColumnName))
        {
            excelTb2.Columns.Add(Temp.Columns[j].ColumnName.ToString());
            ...
        }
    }
