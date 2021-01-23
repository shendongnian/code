    public async Task AddProductProcess(string pName)
    {
        await Task.Factory.StartNew(() =>
            AddProduct(pName));
    }   
    public void AddProduct(string pName)
    {
        ...
        ProductCollection.Add(p);
    }
    public void Add(Product product)
    {
        MainForm.lstProduct.Add(product.Name);
    }
