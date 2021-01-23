            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                if (rows.Cells[3].RowIndex % 2 == 0)
                {
                    rows.Cells[3].Style.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    rows.Cells[3].Style.BackColor = Color.Red;
                }
                else
                {
                    rows.Cells[3].Style.Font = new Font("Arial", 9, FontStyle.Regular);
                    rows.Cells[3].Style.BackColor = Color.Blue;
                }
            }
