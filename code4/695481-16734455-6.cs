    public IQueryable<MyClass> getByYear(int year)
    {
        var dc = new NorthwindBigEntities();
        var query = from p in dc.Order_Details
                    where p.Order.OrderDate != null && p.Order.OrderDate.Value.Year == year
                    select new MyClass
                    {
                        TotalSales = p.UnitPrice * p.Quantity,
                        Product = p.Product.ProductName
                    };
        return query;
    }
