     int supplierId = 20;
             Status.StatusesEnum status = Status.StatusesEnum.Complete;
             PurchaseOrder orderAlias = null;
             IList<PurchaseOrder> orders =
                     Session.QueryOver<PurchaseOrder>(() => orderAlias).WithSubquery
                       .WhereExists(QueryOver.Of<PurchaseOrderStatus>()
                          .Where(c => c.PurchaseOrder.Id == orderAlias.Id)
                          .OrderBy(c=>c.StatusDate)
                          .Desc
                          .Select(c=>c.Status.Id == (int)status)
                          .Take(1)
                          //.Having status = statusID
                          )
                       .Where(o=>o.Supplier.Id == supplierId)
                       .List<PurchaseOrder>();
