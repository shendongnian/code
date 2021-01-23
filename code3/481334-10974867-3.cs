    public DateTime OrderDate
    {
    	get
    	{
    		return this.orderDate;
    	}
    	set
    	{
    		this.orderDate = value;
    		foreach (var item in this.orderItems)
    		{
    			item.CreatedDate = this.OrderDate;
    		}
    	}
    }
