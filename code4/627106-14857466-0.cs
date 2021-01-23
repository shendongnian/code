    private void button1_Click(object sender, EventArgs e)
    {
        DataSet ds = GetUser(textBox1.Text);
        if (ds == null)
        {
             return;
        }
        dataGridView1.DataSource = ds.Tables["Customer"];
    }
