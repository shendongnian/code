    private void button1_Click(object sender, EventArgs e)
    {
        GridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DataGridViewRow row = GridView1.SelectedRows[0];
        GridView1.Rows.Remove(row);
    }
