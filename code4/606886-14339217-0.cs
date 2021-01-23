    Image image;
    private void Form1_Load(object sender, EventArgs e)
    {
        image = Image.FromFile(@"D:\x.jpg");
    }
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        row.DefaultCellStyle.BackColor = Color.Transparent;
    }
    private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        e.Graphics.DrawImage(image, e.RowBounds);
    }
