    public class Car : ICar, IEntity<ICar>
    {
    	public ICar GetThis()
    	{
    		Console.WriteLine("Generic GetThis called");
    		return this;
    	}
    	
    	object IEntity.GetThis()
    	{
    		Console.WriteLine("Non-generic GetThis called");
    		return this;
    	}
    }
