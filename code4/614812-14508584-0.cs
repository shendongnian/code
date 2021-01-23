       private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value != null)
                {
                    if ((bool)e.Value)
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                    else
                        dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
