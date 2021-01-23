    protected override object[] GetCollection()
    {
        Brand brand = ItemLocator.LocateItem(this.Parent, typeof(Brand)) as Brand;
        ICriteria criteria = CoreHttpModule.Session.CreateCriteria(typeof(Product));
        criteria.Add(NHibernate.Expression.Expression.Eq("Brand", brand));
        criteria.Add(NHibernate.Expression.Expression.Eq("IsVisibleOnWebsite", true));
        products[] productList = criteria.List<Product>()
                                             .Where(p => p.Parent != null)
                                             .OrderBy((p => p.Name)
                                             .ToArray();
        return productList;
    }
