    public IQueryable<Products> GetCreatedProducts(int year)
    {
            string sYear = year.ToString();
            return GetAllProducts().Where(m => m.ProductCreationDate.Substring(0,4) == sYear);
    }
