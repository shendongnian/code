    IEnumerable<Order> results = ... // all items
    if (tbOrderId.Text != string.Empty)
    {
       string orderId;
       results = results.Where(t => t.OrderId == orderId);
    }
    if (tbCustomerName.Text != string.Empty)
    {
       string orderId;
       results = results.Where(t => t.CustomerName == customer);
    }
