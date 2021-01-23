    public async Task AddProductProcess(string pName)
    {
        await AddProduct(pName);
    }   
    public async void AddProduct(string pName)  
    {
        ProductItem p =  new ProductItem();
        p.Name = pName ;
        p.Position = Count;
        await p.GetInfo();    // assuming this is doing the heavy work, make async
        ProductCollection.Add(p);
    }
    
