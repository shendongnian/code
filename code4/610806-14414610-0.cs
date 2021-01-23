    private void dataGridView_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
    {
        for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
        {
           dataGridView.Rows[i].Cells[0].Value = false;
        }
    }
