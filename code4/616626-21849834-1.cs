    private void gridViewPro_RowStyle(object sender, 
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        GridView View = sender as GridView;
        if (e.RowHandle >= 0)
        {
            double Sale = Convert.ToDouble(
                View.GetRowCellDisplayText(e.RowHandle, View.Columns["PRO_S3M"]));
            double Qua = Convert.ToDouble(
                View.GetRowCellDisplayText(e.RowHandle, View.Columns["PRO_QTY"]));
            if (Sale > 0 && Qua > 0)
            {
                if (Sale >= Qua)
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
            }
        }
    }
