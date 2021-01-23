    public Form1()
    {
        ... ...
        gridView.RowStateChanged += GridView_RowStateChanged;
    }
    private void GridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
    {
                (sender as DataGridView).Rows[e.Row.Index].Cells[0].Value = e.Row.Index + 1;
    }
