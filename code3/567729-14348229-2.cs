    ...
    private BindingSource Source;
    ...
    
    private void LoadProducts(List<Product> products)
    {
           Source.DataSource = products;
           ProductsDataGrid.DataSource = Source;
    }
    
    private void addProductBtn_Click(object sender, EventArgs e)
    {
           Source.Add(new Product());
    }
