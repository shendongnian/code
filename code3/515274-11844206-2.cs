    private void dataGridViewSites_CellContentClick(object sender, 
        DataGridViewCellEventArgs e)
    {
        dataGridViewSites.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    /// <summary>
    /// Works with the above.
    /// </summary>
    private void dataGridViewSites_CellValueChanged(object sender, 
        DataGridViewCellEventArgs e)
    {
        UpdateDataGridViewSite();
    }
