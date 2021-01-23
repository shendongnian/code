    public double X
    {
    	get
    	{
    		if (this.IsXDefined)
    		{
    			return this.x.Value;
    		}
    
    		throw new PointCoordinateNotDefinedException();
    	}
    }
