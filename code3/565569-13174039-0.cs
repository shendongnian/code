    private void btnSearch_Click(object sender, EventArgs e)
    {
        string searchValue = textBox1.Text;
        int rowIndex = -1;
        dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        try
        {
            foreach (DataGridViewRow row in dgvProjects.Rows)
            {
                if (row.Cells[2].Value.ToString().Equals(searchValue))
                {
                    rowIndex = row.Index;
                    dgvProjects.Rows[row.Index].Selected = true;
                    break;
                }
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
