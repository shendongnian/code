    public Expression<Func<Product, ProjectedProduct>> MapProduct
    {
        get
        {
            return p => new ProjectedProduct { ProdID = p.ID, ProdTitle = p.Title };
        }
    {
