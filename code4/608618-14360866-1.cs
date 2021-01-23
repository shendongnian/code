    DataTable products;
    public Form1()
    {
        InitializeComponent();
        // handle cell changes
        dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        // used for manually raising the ComboBox change
        dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
    }
    void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        // return if the row or column headers were changed
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
        if (e.ColumnIndex != dataGridView1.Columns["total"].Index)
        {
            var value = 0;
            // get the product id from the ComboBox
            var product = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Product"].Index].Value;
            // get the quantity
            var quantity = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["TotalQuantity"].Index].Value.ToString();
            if (product != null && !String.IsNullOrEmpty(quantity))
            {
                value =
                    int.Parse(quantity) *
                    int.Parse(products.Select("product_id = " + product.ToString())[0]["product_price"].ToString());
                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["total"].Index].Value = value;
                dataGridView1.Invalidate();
            }
        }
    }
    void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
