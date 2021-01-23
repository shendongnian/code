    private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // filter for valid DataGridViewCheckBoxCell columns, if desired
        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
