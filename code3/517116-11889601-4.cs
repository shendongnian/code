    public ActionResult GetOrders()
    {
     
      var s = myInventoryEntities.p_Forms().
              Select(i => new  CustomerOrder {
                                               CustomerName= i.Customer, 
                                               OrderID=i.Order_ID
                                             }).Distinct().ToList();
      return View(s);
    }
