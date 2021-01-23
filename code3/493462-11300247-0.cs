    private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        
        if (!IsValueValid(e.FormattedValue))
        {
            e.Cancel = true;
    
            MessageBox.Show("Not Valid!");
        }
    }
