    public async Task AddProductProcess(string pName)
    {
        await Task.Factory.StartNew(() =>
            AddProduct(pName));
    }   
    public void AddProduct(string pName)  // not async
    {
        ...
        ProductCollection.Add(p);
    }
    public void Add(Product product)  // not async
    {
        MainForm.lstProduct.Add(product.Name);
    }
