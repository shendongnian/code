    void Main()
    {
    
    	Yanshoff y = new Yanshoff();
    	y.MyValue = "this is my value!";
    	
    	y.GetType().GetProperties().ToList().ForEach(prop=>
    	{
    		var val = prop.GetValue(y, null);
    		
    		System.Console.WriteLine("{0} : {1}", prop.Name, val);
    	});
    	
    	y.GetType().GetMethods().ToList().ForEach(meth=>
    	{
    		System.Console.WriteLine(meth.Name);
    	});
    	
    }
    
    // Define other methods and classes here
    
    public class Yanshoff
    {
    	public string MyValue {get; set;}
    	
    	public void MyMethod()
    	{
    	     System.Console.WriteLine("I'm a Method!");
    	}
    	
    	
    }
