    private void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvUnit.Rows)
        {
            if(row.Cells["Id"].Value.ToString().ToLower().StartsWith(SearchTextBox.Text.ToLower()))
            {
                row.Visible = true;
                row.Selected = true;
            }
            else
            {
                row.Visible = false;
            }
        }
    }
