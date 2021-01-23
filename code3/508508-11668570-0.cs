    public class MetallicPaint : Car
    {
    	private Car car;
    	public MetallicPaint(Car wrappedCar)
    	{
    		car = wrappedCar;
    	}
    	
    	public decimal Cost()
    	{
    		return car.Cost() + 500;
    	}
    	
    	public string Description()
    	{
    		return car.Description() + ", Metallic Paint";
    	}
    	public string Speed()
    	{
    		return car.Speed();
    	}
    	[... {pass through other methods and properties to the car object}]
    }
