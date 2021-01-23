    public IList<ProductDTO> GetProducts()
    {
    IList<ProductDTO>listofproducts = new List<ProductDTO>();
    using (var db = new NORTHWNDEntities())
    {
        var query = from p in db.Products
                    select new
                    {
                        Name = p.ProductName,     
                    };
        foreach (var product in query)
        {
            productDto.Name = product.Name;
            listofproducts.Add(new ProductDTO {Name = product.Name});
        }
        return listofproducts;
    }     
    }
