    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; ++i)
        {
            dataGridView1.Rows.Add();
        }
        dataGridView1_Resize(this, EventArgs.Empty);
    }
