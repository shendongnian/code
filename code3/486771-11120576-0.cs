    bool comparePrices = true;
    // Join tables and get all products into query
    var query = from a in dc.aProducts
                join t in dc.bProducts on a.sku equals t.sku
    // Now go through each search criteria if needed in order to filter down
    if(comparePrices)
        query = query.Where(p => (double)p.Price >= priceFrom 
                              && (double)p.Price <= priceTo);
    if(!string.IsNullOrEmpty(productSku))
    {
        query = query.Where(t.sku == productSku);
    }
