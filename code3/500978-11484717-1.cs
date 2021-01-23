    private void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows[3].Cells["ImageColumn"] = new DataGridViewTextBoxCell();
        dataGridView1.Rows[3].Cells["ImageColumn"].Value = "Some text!";  
    }
