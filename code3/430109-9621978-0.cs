    IEnumerable<CustomerOrder> customerOrders = (LINQ statement)  
    var param = Expression.Parameter = typeof(CustomerOrder));  
    var sortExpression = Expression.Lambda<Func<CustomerOrder, object>>(Expression.Convert(Expression.Property(param,e.SortExpression), typeof(object), param);  
    MyGridView.DataSource = customerOrders.AsQueryable().OrderBy(sortExpression);  
    MyGridView.DataBind();
