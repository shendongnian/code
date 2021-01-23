    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.tabControl1.SelectedIndex == 1)
        {
            foreach (DataGridViewRow row in this.myGridView.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
            }
        }
    }
