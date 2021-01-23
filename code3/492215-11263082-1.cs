    private void maintainDataControl_RowStyle(object sender, RowStyleEventArgs e)
    {
        if (e.RowHandle >= 0)
        {
            GridView view = sender as GridView;
            // Some condition
            if((string)view.GetRowCellValue(
                e.RowHandle, view.Columns["SomeRow"]).Equals("Some Value"))
            {
                e.Appearance.BackColor = Color.Green;
            }
        }
    }
