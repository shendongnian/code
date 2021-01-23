    private void button1_Click(object sender, EventArgs e)
    {
        DataGridViewTextBoxColumn tb1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn tb2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn tb3 = new DataGridViewTextBoxColumn();
        dataGridView1.Columns.Add(tb1);
        dataGridView1.Columns.Add(tb2);
        dataGridView1.Columns.Add(tb3);
        dataGridView1.Columns[0].HeaderText = "TextBox1";
        dataGridView1.Columns[1].HeaderText = "TextBox2";
        dataGridView1.Columns[2].HeaderText = "TextBox3";
        dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
                
    }
        
