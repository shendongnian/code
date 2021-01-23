    // in Store
    public virtual void Add(Product product)
    {
        if(!Products.Contains(product))
        {
            Products.Add(product);
            product.Add(this);
        }
    }
    // in Product
    public virtual void Add(Store store)
    {
        if(!Stores.Contains(store))
        {
            Stores.Add(product);
            store.Add(this);
        }
    }
