    public class TestClass 
    {
        public static event OrderUpdateHandler UpdatedOrder;
        public void UpdateData(Order order) 
        {
	     	// ...
	        OnOrderUpdated(args);
     	}
        public Order GetConfirmedOrder(int id, TimeSpan waitToConfirm) 
        {
        	var order = GetOrderFromDatabase();
         	if (order.Status == OrderStatus.Pending) 
        	{
        		 var eventHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                 UpdatedOrderHandler waiter = (s, e) =>
                 {
                    if (e.Order.Id == id)
                    {
                        order = e.Order;
                        eventHandle.Set();
                    }
                };
                UpdatedOrder += waiter;
                if (!eventHandle.WaitOne(waitToConfirm))
                {                
                    return order;
                }
                OrderUpdated -= waiter;
        	}
        	return order;
        }
    }
