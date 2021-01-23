    NorthwindDataContext dc;
    private void FrmFilter_Load(object sender, EventArgs e)
    {
      dc = new NorthwindDataContext();
      this.productBindingSource.DataSource = dc.GetTable<Product>();
      productDataGridView.DataSource = productBindingSource;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.productBindingSource.Filter = string.Format("ProductName LIKE '*{0}*'",
                                         textBox1.Text);
    }
