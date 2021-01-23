    public string SelectedValue { get; private set; }
    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
    }
    private void btnSetCC_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }
