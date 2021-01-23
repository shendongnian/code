    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (row.Cells[someColumnIndex].Value == 3)
            row.Cells[someColumnIndex].Style.BackColor = System.Drawing.Color.Blue;
        else if (row.Cells[someColumnIndex].Value == 2)
            row.Cells[someColumnIndex].Style.BackColor = System.Drawing.Color.Red;
    }
