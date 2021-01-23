    public class Attributecollection
    {
    	public string name { get; set; }
    	public int id { get; set; }
    }
    
    public class Input
    {
    	public string soid { get; set; }
    	public string itemname { get; set; }
    	public int qty { get; set; }
    }
    
    public class output
    {
    	public string soid { get; set; }
    }
    
    public class Messageformat
    {
    	public Attributecollection MyAttributecollection { get; set; }
    	public Input MyInput { get; set; }
    	public output Myoutput { get; set; }
    }
    
    ...
    
    Messageformat test = new Messageformat
    	{
    		MyAttributecollection = new Attributecollection { name = "", id = 1 },
    		MyInput = new Input { soid = "", itemname ="", qty = 1 },
    		Myoutput = new output { soid = "" }
    	};
