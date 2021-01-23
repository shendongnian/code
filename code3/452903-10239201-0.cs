    var amount = (decimal)Session.CreateCriteria<Transaction>()
        .Add(Expression.Eq("Account.Id", accountId))
        .Add(Expression.In("StatusType.Id", statusTypes))
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.GroupProperty("Account.Id"))
            .Add(Projections.Sum("InvoiceGross"), "total"))
        .SetMaxResults(1)
        .List();
    
    var sum=amount[0][1];
