    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }));
            }
        }
    }
