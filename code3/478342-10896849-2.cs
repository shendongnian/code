    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow r in dataGridView1.Rows)
        {
            if (System.Uri.IsWellFormedUriString(r.Cells["Contact"].Value.ToString(), UriKind.Absolute))
            {
                r.Cells["Contact"] = new DataGridViewLinkCell();
                // Note that if I want a different link colour for example it must go here
                DataGridViewLinkCell c = r.Cells["Contact"] as DataGridViewLinkCell;
                c.LinkColor = Color.Green;
            }
        }
    }
