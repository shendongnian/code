    private void UpdateOrder(Order o)
    {
      //Get the corresponding order from the database (I suspect Entity Framework here in order to get an object?)
      Order dbOrder = OrderVisaOrderInformation(o.Id);
      if (dbOrder.Equals(o))
      {
        //Do some update
      }
    }
    private void UpdateManyOrders(List<Order> orders)
    {
      var dbOrders = (from order in orders
                      select OrderVisaOrderInformation(order.Id));
      List<Order> ordersToUpdate = dbOrders.Where(x => !x.Equals(orders.First(y => y.Id == x.Id))).ToList();
      foreach (Order orderToUpdate in ordersToUpdate)
      {
        //Update the order
      }
    }
