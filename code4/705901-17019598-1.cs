    Expression<Func<Order, bool>> predicate = t => true;
    if (tbOrderId.Text != string.Empty)
    {
       string orderId;
       predicate = Expression.AndAlso(predicate, t => t.OrderId == orderId);
    }
    if(tbCustomerName.Text != string.Empty)
    {
       string customer = tbCustomerName.Text;
       predicate = Expression.AndAlso(predicate, t => t.CustomerName == customer);
    }
    return results.Where(predicate);
