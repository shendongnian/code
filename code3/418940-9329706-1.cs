    class customcell : DataGridViewLinkCell
    {
        public string link;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        DataGridViewLinkColumn c = new DataGridViewLinkColumn();
        dataGridView1.Columns.Add(c);
        dataGridView1.Rows.Add();
        dataGridView1.Rows[0].Cells[0].Value = "search";
        ((customcell)(dataGridView1.Rows[0].Cells[0])).link = "http://www.google.com";
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        Process.Start(((customcell)(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex])).link);
    }
