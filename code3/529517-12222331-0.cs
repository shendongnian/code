    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        // You could also check here to see if the cell in question is the combobox
        if (dataGridView1.IsCurrentCellDirty)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
