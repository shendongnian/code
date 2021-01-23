    private void MyDataGridView_CellDoubleClick(object sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            // header was clicked
        }
        else
        {
            // data row was clicked, can access the row contents like this
            var row = MyDataGridView.Rows[e.RowIndex];
            var cell = row[0];
        }
    }
