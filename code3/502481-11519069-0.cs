    public void SearchProducts()
    {
        //Filter by search string array(searchArray)
        List<string> prodId = new List<string>();
        StoreProductCollection prod = new StoreProductCollection();
        
        // Notice that your foreach() is gone
    
        // replace this
        // prod.Query.Where(prod.Query.StptName.ToLower() == src.ToLower() && prod.Query.StptDeleted.IsNull());
        // with this (or something similar: point is, you should call .Load() exactly once)
        prod.Query.where(prod.Query.StptDeleted.IsNull() && src.Any(srcArrayString => prod.Query.StptName.ToLower()==srcArrayString.ToLower());
        
        prod.Query.Select(prod.Query.StptName, prod.Query.StptPrice, prod.Query.StptImage, prod.Query.StptStoreProductID);
        //  prod.Query.es.Top = 4;
        prod.Query.Load();
        
        // ... rest of your code follows. 
    }
