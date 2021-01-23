    private void GridCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == ColQuantityIssues.Index)  // Quantity Issues TextBox value has changed
        {
            int quantityIssued = 0;
    
            if (!Int32.TryParse(e.FormattedValue.ToString(), out quantityRequired))  //value is not a valid number
            {
                e.Cancel = true;
            }
    
            int quantityRequired = Int32.Parse(dgv.Rows[e.RowIndex].Cells[ColQuantityRequired.Index].Value.ToString());
    
            if (quantityRequired < quantityIssued)
            {
                e.Cancel = true;
            }
        }
    }
