    void gridView1_CustomUnboundColumnData(object sender,
    DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
        if (e.Column.FieldName == "Percent" && e.IsGetData) {
            GridView view = (GridView)sender;
            DataRow row = view.GetDataRow(e.RowHandle); //If datasource = datatable
            //Use GetRow if custom business object and cast it.
            e.Value = Value*100 + "%"; //I am sure there is a better way.
        }
    }
