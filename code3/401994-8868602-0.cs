     foreach (DataGridViewRow row in this.DataGridView1.Rows)
            {
                if (row.Cells[5].Text == "ok")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
