    interface IReadOnlyData
    {
    	double GetZ();
    }
    
    class SharedData : IReadOnlyData
    {
    	 public double Z { get; set; }
    	 IReadOnlyData.GetZ() { return Z; }
    }
    
    class Square
    {
    	private IReadOnlyData Data;
    	
    	public Square(IReadOnlyData data)
    	{
    		this.Data = data;
    	}
    }
