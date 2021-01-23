    public class SalesService : IBaseService<Order>, IBaseService<Request>
    {
    	IList<Order> IBaseService<Order>.GetAll()
    	{
    		//return orders
    	}
    	
    	IList<Request> IBaseService<Request>.GetAll()
    	{
    		//return requests
    	}
    }
