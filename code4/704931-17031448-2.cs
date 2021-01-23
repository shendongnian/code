    IEnumerable<WorkOrder> orders = _context.GetWorkOrders(UserName, workOrder, customerCode).ToList();
    OrderStatus lastStatus = new OrderStatus();
    foreach (Order order in orders)
    {
        ObjectParameter workOrderParameter;
        if (wo.WorkOrder != null)
        {
            workOrderParameter = new ObjectParameter("WorkOrder", order.WorkOrder);
        }
        else
        {
           workOrderParameter = new ObjectParameter("WorkOrder", typeof(global::System.String));
        }
        lastStatus = _context.ExecuteFunction<OrderStatus>("GetOrderStatus", MergeOption.OverwriteChanges, workOrderParameter).FirstOrDefault();
        if (status != null)
        {
            order.LastOrderStatus = status.OrderStatus;
        }
    }
