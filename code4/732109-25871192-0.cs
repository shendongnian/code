    public void ExecuteReader()
    {
        var dt = new DataTable();
        dt.Load(connection.ExecuteReader("select 3 as [three], 4 as [four]"));
        dt.Columns.Count.IsEqualTo(2);
        dt.Columns[0].ColumnName.IsEqualTo("three");
        dt.Columns[1].ColumnName.IsEqualTo("four");
        dt.Rows.Count.IsEqualTo(1);
        ((int)dt.Rows[0][0]).IsEqualTo(3);
        ((int)dt.Rows[0][1]).IsEqualTo(4);
    }
