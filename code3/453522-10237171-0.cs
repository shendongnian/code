    var query = Repository.Orders;
    if(orderNo > 0)
    {
        query = query.Where( x => x.OrderId == orderNo);
    }
    if(firstName.Length > 0)
    {
       query = query.Where( x => x.FirstName == firstName);
    }
    //...
