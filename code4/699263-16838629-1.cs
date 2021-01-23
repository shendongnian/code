        StockLevelRowVM rowVM = null;
        Stock s = null;
        Company c = null;
        State state = null;
        Country country = null;
        Product p = null;
        TransactionHeader ith = null;
        TransactionRow itr = null;
        TransactionHeader oth = null;
        TransactionRow otr = null;
        var stockQuery = session.QueryOver<Stock>(() => s)
            .JoinAlias<Company>(() => s.company, () => c, NHibernate.SqlCommand.JoinType.InnerJoin, null)
            .JoinAlias<State>(() => c.State, () => state, NHibernate.SqlCommand.JoinType.InnerJoin, null)
            .JoinAlias<Country>(() => c.Country, () => country, NHibernate.SqlCommand.JoinType.InnerJoin, null)
            .JoinAlias<Product>(() => s.product, () => p, NHibernate.SqlCommand.JoinType.InnerJoin, null)
            .JoinAlias<TransactionHeader>(() => c.TransactionsFromCompany, () => oth, NHibernate.SqlCommand.JoinType.LeftOuterJoin, null)
            .JoinAlias<TransactionRow>(() => oth.Rows, () => otr, NHibernate.SqlCommand.JoinType.LeftOuterJoin, null)
            .JoinAlias<TransactionHeader>(() => c.TransactionsToCompany, () => ith, NHibernate.SqlCommand.JoinType.LeftOuterJoin, null)
            .JoinAlias<TransactionRow>(() => ith.Rows, () => itr, NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
        if (productId.HasValue) { stockQuery = stockQuery.Where(() => p.Id == productId); }
        if (companyId.HasValue) { stockQuery = stockQuery.Where(() => c.Id == companyId); }
        if (stateId.HasValue) { stockQuery = stockQuery.Where(() => state.Id == stateId); }
        if (countryId.HasValue) { stockQuery = stockQuery.Where(() => country.Id == countryId); }
        <call generic paging methods for IQueryOver>
        result = stockQuery.SelectList(list => list
                    .SelectGroup(() => c.Id)
                    .SelectGroup(() => p.Id)
                    .SelectGroup(() => c.Description).WithAlias(() => rowVM.CompanyName)
                    .SelectGroup(() => state.Description).WithAlias(() => rowVM.StateName)
                    .SelectGroup(() => country.Description).WithAlias(() => rowVM.CountryName)
                    .SelectGroup(() => p.Description).WithAlias(() => rowVM.ProductName)
                    .SelectSum(() => s.currentStock).WithAlias(() => rowVM.CurrentStock)
                    .SelectSum(() => otr.Quantity).WithAlias(() => rowVM.OutgoingStock)
                    .SelectSum(() => itr.Quantity).WithAlias(() => rowVM.IncommingStock))
                .TransformUsing(Transformers.AliasToBean<StockLevelRowVM>())
                .List<StockLevelRowVM>().ToList();
