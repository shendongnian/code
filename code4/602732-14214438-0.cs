    public class OrderModel
    {
    	protected bool _detailed;
    
    	[Key, Column(Order=0), DatabaseGenerated(DatabaseGeneratedOption.None)]
    	[JsonProperty(PropertyName = "order_id")]
    	public int Id { get; set; }
    
    	[Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
    	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    	public bool Detailed
    	{
    		get { return _detailed; }
    		set
    		{
    			if( (this.GetType() == typeof(OrderModel) && value== true) ||
    				(this.GetType() == typeof(OrderDetailedModel) && value==false))
    				throw new ArgumentException("This property is restricted");
    			_detailed = value;
    		}
    	}
    	
    	//....
    	
    	public OrderModel()
    	{
    		_detailed = false;
    	}
    }
    
    
    public class OrderDetailedModel :OrderModel
    {
    	//.....
    
    	public OrderDetailedModel()
    	{
    		_detailed = true;
    	}
    }
