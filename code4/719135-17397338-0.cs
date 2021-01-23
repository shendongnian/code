    private Image image1 = Bitmap.FromFile("C:/Image1.png");
    private Image image2 = Bitmap.FromFile("C:/Image2.png");
    public void dgvInit()
    {
        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
        imgColumn.Name = "images";
        imgColumn.HeaderText = "images";
        imgColumn.Image = this.image1;			
        this.dataGridView1.Columns.Add(imgColumn);
        this.dataGridView1.Rows.Add(new DataGridViewRow());
        this.dataGridView1.CellClick += new 
            DataGridViewCellEventHandler(dataGridView1_CellClick);			
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "images")
        {
            DataGridViewImageColumn imgColumn =
                (DataGridViewImageColumn)this.dataGridView1.Columns[e.ColumnIndex];
            if (imgColumn.Image == this.image1) imgColumn.Image = image2;
            else imgColumn.Image = image1;
        }
    }
