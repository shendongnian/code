    void Main()
    {
    	var orders = new List<Order>{
    		new Order{OrderId = 1, DeliverIn = 5},
    		new Order{OrderId = 2, DeliverIn = 6},
    		new Order{OrderId = 3, DeliverIn = 5},
    	};
    	
    	var lines = new List<OrderLine>{
    	  new OrderLine{LineId = 1, OrderId = 1, ProductId = 1},
    	  new OrderLine{LineId = 2, OrderId = 1, ProductId = 2},
    	  new OrderLine{LineId = 3, OrderId = 1, ProductId = 3},
    	  
    	  new OrderLine{LineId = 4, OrderId = 2, ProductId = 1},
    	  new OrderLine{LineId = 5, OrderId = 2, ProductId = 3},
    	  new OrderLine{LineId = 6, OrderId = 2, ProductId = 4},
    	};
    	
    	var query = from o in orders join l in lines on
    	     	o.OrderId equals l.OrderId
    			group o by o into grouped
    			select new 
    			{
    				Count = grouped.Count(),
    				grouped.Key.OrderId,
    				grouped.Key.DeliverIn
    			};
    			Console.WriteLine(query);
    }
    
    // Define other methods and classes here
    public class Order
    {
    	public int OrderId{get;set;}
    	public int DeliverIn{get;set;}
    	
    }
    
    public class OrderLine
    {
        public int LineId{get;set;}
    	public int OrderId{get;set;}
    	public int ProductId{get;set;}
    }
