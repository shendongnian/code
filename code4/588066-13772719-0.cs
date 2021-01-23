    void Main()
    {
    	//populate
    	var dbOrderItems = new List<OrderItem>();
    	dbOrderItems.Add(new OrderItem { OrderId = 1, ProductVariantId = 4 });
    	dbOrderItems.Add(new OrderItem { OrderId = 1, ProductVariantId = 5 });
    	dbOrderItems.Add(new OrderItem { OrderId = 1, ProductVariantId = 6 });
    	dbOrderItems.Add(new OrderItem { OrderId = 2, ProductVariantId = 10 });
    	dbOrderItems.Add(new OrderItem { OrderId = 2, ProductVariantId = 11 });
    	dbOrderItems.Dump();
    	
    	Dictionary<int, Order> order_list = new Dictionary<int, Order>();
    	foreach(OrderItem orderItem in dbOrderItems)
    	{
    		if (order_list.ContainsKey(orderItem.OrderId))
    		{
    			var currOrderItems = order_list[orderItem.OrderId].OrderItems;
    			if (currOrderItems.Contains(orderItem) == false)
    			{
    				// order exists, add new order item
    				currOrderItems.Add(orderItem);
    				order_list[orderItem.OrderId].OrderItems = currOrderItems; 
    			}
    		}
    		else
    		{
    			// new order
    			order_list.Add(orderItem.OrderId, new Order { OrderId = orderItem.OrderId, OrderItems = new List<OrderItem> { orderItem } });
    		}
    	}
    	
    	order_list.Dump();
    	
    }
    
    // Define other methods and classes here
    public class OrderItem
    {
    	public int OrderId {get;set;}
    	public int ProductVariantId {get;set;}
    }
    
    public class Order
    {
    	public int OrderId {get;set;}
    	public List<OrderItem> OrderItems {get;set;}
    }
