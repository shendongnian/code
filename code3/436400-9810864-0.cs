    using (var orderContext = new ShippingEntities())
    {
        orderContext.ShippingOrders.AddObject(shippingOrder);
        foreach (var shippingOrderItem in shippingOrder.ShippingOrderItems)
        {
            orderContext.ObjectStateManager.ChangeObjectState(
                shippingOrderItem, EntityState.Modified);
        }
        orderContext.ObjectStateManager.ChangeObjectState(
            shippingOrder, EntityState.Modified);
        orderContext.SaveChanges();
    }
