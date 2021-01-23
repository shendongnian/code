    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Eid_txt.Text = row.Cells["Employee ID"].Value.ToString();
            Name_txt.Text = row.Cells["First Name"].Value.ToString();
            Surname_txt.Text = row.Cells["Last Name"].Value.ToString();
