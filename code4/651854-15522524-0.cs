    void DataGridView_ReadOnlyChanged(object sender, EventArgs e)
    {
        DataGridView dataGridView = (DataGridView) sender;
        if (!dataGridView.ReadOnly)
        {
            // DataGridView.ReadOnly has just been set to false, so we need to 
            // restore each row's readonly state.
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Tag != null && ((bool)row.Tag))
                {
                    row.ReadOnly = true;
                }
            }
        }
    }
