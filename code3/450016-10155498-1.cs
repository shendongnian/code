        void gridView1_CustomUnboundColumnData(object sender,
                   DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Total" && e.IsGetData) 
                e.Value = 100;
        }
