    // You haven't executed the query yet, you can still build up what you need
    IQueryable<Order> query = Repository.Orders;
    if(orderNo >0){
        // You STILL haven't actually executed the query.
        query.Where(x => x.orderNo == orderNo);
    }
    if(firstName.Length > 0){
        query.Where(x => x.firstname == firstName);
    }
    if(lastName.Length > 0){
        query.Where(x => x.lastName == lastName);
    }
    // Even with this, you STILL aren't actually executing the query.
    var result = query.OrderByDescending(x => x.orderNo);
    // You'll be executing and enumerating the results here, but that's OK because you've fully defined what you want.
    return Json(result, JsonRequestBehavior.AllowGet);
