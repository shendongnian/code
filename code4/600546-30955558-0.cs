    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex > -1 && e.ColumnIndex == dataGridView1.Columns["colCheck"].Index)
            {
                if (e.Value != null)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["colCheck"].Value.ToString() == "1")
                    {
                        for (int i = 0; i < this.dataGridView1.Columns.Count; i++ )
			            {
                            this.dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.dataGridView1.Columns.Count; i++ )
			            {
                            this.dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
    }
