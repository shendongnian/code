    private void dgvSJ_EditingControlShowing(object sender,   DataGridViewEditingControlShowingEventArgs e)
    {
        if (dgvSJ.CurrentCell.ColumnIndex == 10)
        {
            RichTextBox rtx = e.Control as RichTextBox ; 
            rtx.SelectionColor = Color.CornflowerBlue;
            rtx.TextChanged += new EventHandler(tx_TextChanging);
        }
    }            
