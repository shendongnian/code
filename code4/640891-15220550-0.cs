    //...
    GridColumn colSubTotal = gridView1.Columns.AddField("SubTotal");
    colSubTotal.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
    colSubTotal.Visible = true;
    colSubTotal.Caption = "Budget";
    gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
    //...
    void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
        GridView view = sender as GridView;
        if(e.Column.FieldName != "SubTotal") return;
        if(!e.IsGetData) return;
        DataRow row = ((view.DataSource as IList)[e.ListSourceRowIndex] as DataRowView).Row;
        int subTotal = 0;
        foreach(DataRow childRow in row.GetChildRows("Project_Tasks")) 
            subTotal += (int)childRow["Budget"];
        e.Value = subTotal;
    }
