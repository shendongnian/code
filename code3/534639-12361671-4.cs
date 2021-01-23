    public abstract class OrderBase
    {
    	public int OrderID { get; private set; }
    	public string Name { get; protected set; }
    	
    	public OrderBase()
    	{
    		
    	}
    	
    	public OrderBase(OrderBase copiedOrder)
    	{
    		this.OrderID = copiedOrder.OrderID;
    		this.Name = copiedOrder.Name;
    	}
    }
