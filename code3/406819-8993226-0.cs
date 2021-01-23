    public Form1() {
      InitializeComponent();
      dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
      dataGridView1.Columns.Add(new DataGridViewLinkColumn());
      dataGridView1.Rows.Add(1);
      dataGridView1.Rows[0].Cells[0].Value = "File #1";
      dataGridView1.Rows[0].Cells[1].Value = "Click here";
      dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
    }
    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 1) {
        MessageBox.Show("Downloading " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
      }
    }
