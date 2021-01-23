    public DataTable joinTables (DataTable t1, DataTable t2)
    {
        DataTable t = new DataTable();
        AddColumns(t1, t);
        AddColumns(t2, t);
    
        for (int i = 0; i < t1.Rows; i++)
        {
            DataRow newRow = t.NewRow();
    
            for (int j = 0; j < t1.Columns.Count; j++)
            {
                SetMergedRowValue(t1.Rows[i], newRow, j);
                SetMergedRowValue(t2.Rows[i], newRow, j);
            }
    
            t.Rows.Add(newRow);
        }
    
        t.AcceptChanges();
    }
    
    private void AddColumns(DataTable source, DataTable target)
    {
        foreach (DataColumn c in source.Columns)
        {
            target.Columns.Add(string.Format("{0}_{1}", source.TableName, c.ColumnName), c.DataType);
        }
    }
    
    private void SetMergedRowValue(DataRow source, DataRow target, int index)
    {
        var columnName = string.Format("{0}_{1}", source.Table.TableName, source.Table.Columns[index]);
        target[columnName] = source[index];
    }
