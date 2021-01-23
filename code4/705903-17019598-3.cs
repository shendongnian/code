    ParameterExpression parameter = Expression.Parameter(typeof(DateTime));
    Expression predicate = Expression.Constant(true);
    if (tbOrderId.Text != string.Empty)
    {
       string orderId = tbOrderId.Text;
       Expression prop = Expression.PropertyOrField(parameter, "OrderId");
       Expression filter = Expression.Equal(prop, Expression.Constant(orderId));
       predicate = Expression.AndAlso(predicate, filter);
    }
    if(tbCustomerName.Text != string.Empty)
    {
       string customer = tbCustomerName.Text;
       Expression prop = Expression.PropertyOrField(parameter, "CustomerName");
       Expression filter = Expression.Equal(prop, Expression.Constant(customer))
       predicate = Expression.AndAlso(predicate, filter);
    }
    Expression lambda = Expression.Lambda(predicate, parameter);
    return results.Where(lambda);
