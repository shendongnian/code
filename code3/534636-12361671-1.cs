    public class CustomOrder : OrderBase
    {
    	public Guid CustomID { get; private set; }
    
    	public CustomOrder()
    	{
    	
    	}
    	
    	public CustomOrder(CustomOrder copiedOrder)
    		: base(copiedOrder)
    	{
    		this.CustomID = copiedOrder.CustomID;
    	}
    }
