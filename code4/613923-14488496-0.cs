    public Domain.Order GetOrder(int orderID)
    {
        Data.Order order = context.Orders.Where(o => o.OrderID = orderID);  // 
        Domain.Order newOrder = Map(order);
        return newOrder;
    }
    
    public Domain.Order Map(Data.Order order)
    {
        if (!UsingAutomapper)
        {
            // raw way
            Domain.Order newOrder = new Domain.Order
                               {
                                   ID         = order.OrderID,
                                   Number     = order.OrderNumber,
                                   OrderDate  = order.OrderDate
                               };
            return newOrder;
        }
        else  // let AutoMapper do the dirty work
        {
            return Mapper.Map(order);
        }
    }
