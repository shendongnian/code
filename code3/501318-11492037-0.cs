    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow r in dataGridView1.Rows)
        {
            r.Cells["AutoGenColumn"].Value = r.Index + 1;
        }
    }
