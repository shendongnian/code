    private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
        GridView View = sender as GridView;
        if (e.Column.FieldName == "First Name" &&
            string.IsNullOrEmpty(View.GetRowCellDisplayText(e.RowHandle, e.Column)))
        {
            e.Appearance.BackColor = Color.DeepSkyBlue;
        }
    }
