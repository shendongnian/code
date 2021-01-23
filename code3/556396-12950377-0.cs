    ICriteria criteria = NHibernateSession
        .CreateCriteria<SaleItem>("SaleItem")
        .SetMaxResults(10)
        .CreateCriteria("ID.Product")
            .SetProjection(Projections.ProjectionList()
                .Add(Projections.GroupProperty("ID.Product"), "ID")
                .Add(..., "...") // another Product property
                .Add(Projections.Sum("SaleItem.Quantity"), "QuantitySum")
            )
            .AddOrder(Order.Desc("QuantitySum"));
    
    List<Product> l = criteria
        .SetResultTransformer(Transformers.AliasToBean<Product>());
        .List<Product>() as List<Product>;
