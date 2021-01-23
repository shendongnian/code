    private void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            List<DataRow> toDelete = new List<DataRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell check = row.Cells[0] as DataGridViewCheckBoxCell;
                if (check.Value != null && (bool)check.Value)
                  toDelete.Add(((DataRowView)row.DataBoundItem).Row);
            }
            toDelete.ForEach(row => row.Delete());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
