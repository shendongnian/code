    /* You can use grid's cell validating event.  
     ColMinimumQuantity, ColMaximumQuantity, ColMinimumAmount, ColMaximumAmount are grid's column name
     you can set them in Grid Properties. */
    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (dataGridView1.CurrentCell.OwningColumn.Name.ToUpper().ToString() == "ColMaximumQuantity")
        {
            dataGridView1.CurrentRow.Cells["ColMinimumQuantity"].Value = "0";
            dataGridView1.CurrentRow.Cells["ColMaximummQuantity"].ReadOnly = false;
            dataGridView1.CurrentRow.Cells["ColMinimummQuantity"].ReadOnly = true;
        }
    
        if (dataGridView1.CurrentCell.OwningColumn.Name.ToUpper().ToString() == "ColMaximumAmount")
        {
            dataGridView1.CurrentRow.Cells["ColMinimumAmount"].Value = "0";
            dataGridView1.CurrentRow.Cells["ColMaximummQuantity"].ReadOnly = false;
            dataGridView1.CurrentRow.Cells["ColMinimummQuantity"].ReadOnly = true;
        }
    
        if (dataGridView1.CurrentCell.OwningColumn.Name.ToUpper().ToString() == "ColMinimumAmount")
        {
            dataGridView1.CurrentRow.Cells["ColMaximumAmount"].Value = "0";
            dataGridView1.CurrentRow.Cells["ColMiniimumAmount"].ReadOnly = false;
            dataGridView1.CurrentRow.Cells["ColMaximumAmount"].ReadOnly = true;
        }
    }
