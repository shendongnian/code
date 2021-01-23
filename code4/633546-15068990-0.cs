    Expression<Func<Product, ProductInCityDto>> GetAllProducts
    {
        get
        {
            return product => new ProductInCityDto
            {
                 ProductName = product.ProductName,
                 CityName = product.Store.City.Name,
                 CountryName = product.Store.City.Country.Name,
                 //Bit of a hack to coerce the Provider out...
                 ProductAvgPrice = product.Sales
                        .AsQueryable.Provider
                        .Execute<double>(CalculateAvg(product), Expression.Constant(product, typeof (Product)) ),
                 . 
                 . 
                 .  
            }
        }
    }
    public Expression<Func<Product, double>> CalculateAvg()
    {
        return product => product.Sales.Where(n => n.type != 1).Average(n=>n.Price);
    }
