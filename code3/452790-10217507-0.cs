    // subscribe the event using code
    yourDataGridView.CellClick += new DataGridViewCellEventHandler(YourGridView_CellClick);
    // handle the event
    private void YourGridView_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {
        DataGridViewImageCell cell = (DataGridViewImageCell)
            yourDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
       yourTextBox.Text = cell.Value;
    }
