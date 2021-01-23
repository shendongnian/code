    private void DataGridView1OnCellValueChanged(object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs)
    {
        // Remove focus
        dataGridView1.CurrentCell = null;
        // Put in updates
        Update();
    }
    private void DataGridView1OnCurrentCellDirtyStateChanged(object sender, EventArgs eventArgs)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
            
    }
