    void Main()
    {
    	var myCar = new Car{ Color =  Color.Black, Make="Toyota"};
    	
    	Option<Car> optional = Option<Car>.Create(myCar);
    
        // optional is an Empty 50% of the time.
    	if(new Random().NextDouble() > 0.5)
    		optional = Option<Car>.CreateEmpty();
             	
    	string color = optional
    	.Select(car => car.Color.Name)
    	.DefaultIfEmpty("<no car>")
    	.Single();
    	Console.Write(color);
    }
    
    class Car {
    	public Color Color { get; set; }
    	public string Make { get; set;}
    }
    
    public class Option<T> : IEnumerable<T>
    {
    	private readonly T[] data;
    
    	private Option(T[] data)
    	{
    		this.data = data;
    	}
    
    	public static Option<T> Create(T value)
    	{
    		return new Option<T>(new T[] { value });
    	}
    
    	public static Option<T> CreateEmpty()
    	{
    		return new Option<T>(new T[0]);
    	}
    
    	public IEnumerator<T> GetEnumerator()
    	{
    		return ((IEnumerable<T>)this.data).GetEnumerator();
    	}
    
    	System.Collections.IEnumerator
    		System.Collections.IEnumerable.GetEnumerator()
    	{
    		return this.data.GetEnumerator();
    	}
    }
