    class Fruit
    {
    	public float Weight { get; set; }	
    }
    
    interface IPackable { }
    
    class Apple : Fruit, IPackable
    {
    
    }
    
    class FruitPacker
    {
    	void Pack(IPackable fruit)
    	{
    		// pack fruit
    	}
    }
