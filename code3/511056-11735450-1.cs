    public YourService : YourServiceInterface
    {
    	public void UpdateOrder(Order order)
    	{
    		using (context = new DatabaseContext())
    		{
    			context.Orders.Where(o => o.ID == order.ID).First().IsConfirmed = order.IsConfirmed;
    			context.SaveChanges();
    		}
    	}
    	
    	public Boolean? GetConfirmationResult(Order order)
    	{
    		using (context = new DatabaseContext())
    		{
    			return context.Orders.Where(o => o.ID == order.ID).First().IsConfirmed;
    		}
    	}	
    }
