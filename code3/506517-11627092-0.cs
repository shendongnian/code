    var col = gridView1.Columns.Add();
    col.FieldName = "counter";
    col.Visible = true;
    col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
    gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
    void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (e.IsGetData)
            e.Value = e.ListSourceRowIndex+1;
    }
