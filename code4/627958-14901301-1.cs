    //Entity class that contains all the data for my grid
    var purchaseOrders = _purchaseOrders.GetPurchaseOrders();
    var tempPurchaseOrders = new List<PurchaseOrder>();
    var requestors = new List<RequestorData>();
    var customers = purchaseOrders.Select(po => po.Requestor).Distinct().ToList();
    var units = purchaseOrders.Select(po => po.Unit).Distinct().ToList();
    
    foreach (var customer in customers)
    {
       if (customer != null)
          requestors.Add(new RequestorData { entityId = customer.Id, Name = customer.FullName, isRequestorId = true });
    }
    foreach (var unit in units)
    {
       if (unit != null)
         requestors.Add(new RequestorData { entityId = unit.Id, Name = unit.FullName, isRequestorId = false });
    }
    
    requestors = requestors.OrderBy(r => r.Name).ToList();
    
    foreach (var requestor in requestors)
    {
       var id = requestor.entityId;
       if (requestor.isRequestorId)
          tempPurchaseOrders.AddRange(purchaseOrders.Where(po => po.RequestorId == id).ToList());
       else
          tempPurchaseOrders.AddRange(purchaseOrders.Where(po => po.UnitId == id).ToList());
    }
    
    purchaseOrders = tempPurchaseOrders.AsQueryable();
    return purchaseOrders;
