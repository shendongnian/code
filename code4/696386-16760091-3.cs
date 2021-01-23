    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            if (cell.Value !=null)
            {
                MessageBox.Show(cell.Value.ToString());
            }
        }
    }
