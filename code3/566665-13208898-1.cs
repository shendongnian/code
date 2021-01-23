    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (dataGridView1.CurrentCell.OwningColumn.Name.ToUpper().ToString() == "ColMinimumQuantity")
        {
            dataGridView1.CurrentRow.Cells["ColMaximumQuantity"].Value = "0";
            dataGridView1.CurrentRow.Cells["ColMinimumQuantity"].ReadOnly = false;
            dataGridView1.CurrentRow.Cells["ColMaximumQuantity"].ReadOnly = true;
        }
    
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
