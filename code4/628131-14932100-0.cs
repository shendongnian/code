    private void simpleButton1_Click_1(object sender, EventArgs e)
    {
        i++;
        int index = i % _Tbl.Columns.Count;
        DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.AddVisible(_Tbl.Columns[index].ColumnName);
        col.Name = "Column_{0}" + i;
        col.FieldName = "Column_{0}" + i";
    }
