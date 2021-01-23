    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow r in dataGridView1.Rows)
        {
            if (!System.Uri.IsWellFormedUriString(r.Cells["Contact"].Value.ToString(), UriKind.Absolute))
            {
                r.Cells["Contact"] = new DataGridViewTextBoxCell();
            }
        }
    }
