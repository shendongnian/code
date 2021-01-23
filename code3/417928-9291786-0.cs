    public class Core
    {
    	public Core(int param1, int param2)
    	{
    		this.Calculations = new Calculations { Parameter1 = param1, Parameter2 = param2 };
    	}
    
    	public Calculations Calculations { get; private set; }
    }
    
    public class Calculations
    {
    	public double Parameter1 { get; set; }
    
    	public double Parameter2 { get; set; }
    
    	public double Calc1()
    	{
    		return this.Parameter1 * this.Parameter2;
    	}
    }
