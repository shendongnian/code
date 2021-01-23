     int nRow;
    private void Form1_Load(object sender, EventArgs e)
    {
        nRow = dataGridView1.CurrentCell.RowIndex;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (nRow < dataGridView1.RowCount )
        {
            dataGridView1.Rows[nRow].Selected = false;
            dataGridView1.Rows[++nRow].Selected = true;
        }
    }
