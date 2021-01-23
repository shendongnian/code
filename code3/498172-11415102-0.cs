    PurchaseOrder orderAlias = null;
    
                 IList<PurchaseOrder> orders =
                         Session.QueryOver<PurchaseOrder>(() => orderAlias).WithSubquery
                           .WhereExists(QueryOver.Of<PurchaseOrderStatus>()
                              .Where(c => c.PurchaseOrder.Id == orderAlias.Id)
                              .OrderBy(c=>c.StatusDate)
                              .Desc
                              .Select(c=>c.PurchaseOrder)
                              .Take(1))
                           .List<PurchaseOrder>();
