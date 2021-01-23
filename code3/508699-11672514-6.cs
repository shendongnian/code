    private DataTable dt = new DataTable("Test");
    private BindingSource bs;
    public Form1() {
      InitializeComponent();
      dt.Columns.Add("ProductName", typeof(string));
      DataRow dr1 = dt.NewRow();
      dr1["ProductName"] = "One A";
      dt.Rows.Add(dr1);
      DataRow dr2 = dt.NewRow();
      dr2["ProductName"] = "One B";
      dt.Rows.Add(dr2);
      DataRow dr3 = dt.NewRow();
      dr3["ProductName"] = "Two A";
      dt.Rows.Add(dr3);
      DataRow dr4 = dt.NewRow();
      dr4["ProductName"] = "Two B";
      dt.Rows.Add(dr4);
      bs = new BindingSource(dt, null);
      dataGridView1.DataSource = bs;
    }
    private void textBox1_TextChanged(object sender, EventArgs e) {
      if (textBox1.Text == string.Empty) {
        bs.RemoveFilter();
      } else {
        bs.Filter = string.Format("ProductName LIKE '*{0}*'", textBox1.Text);
      }
    }
