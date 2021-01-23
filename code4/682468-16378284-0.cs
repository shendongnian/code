    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            if (cell.Value != null)
                cell.Style.BackColor = Color.Red;
            else
                cell.Style.BackColor = Color.White;
        }
    }
