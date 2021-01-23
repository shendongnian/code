      private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[].Value.ToString() == "good")
                {
                    e.CellStyle.BackColor = Color.PaleGreen;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.SelectionBackColor = Color.Wheat;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "warning")
                {
                    e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                    e.CellStyle.SelectionForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.Wheat;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "error")
                {
                    e.CellStyle.BackColor = Color.Salmon;
                    e.CellStyle.SelectionForeColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.Wheat;
                }
                    if (e.Value.ToString() == "Yellow")
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else
                        if (e.Value.ToString() == "Blue")
                        {
                            e.CellStyle.BackColor = Color.LightBlue;
                        }
            }
        }
