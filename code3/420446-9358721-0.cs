    public class Unit1
    {
    	public Unit1(string name)
    	{
    		this.Name = name;
    
    		switch (this.Name)
    		{
    			case "XXS":
    				this.Size = 1;
    				break;
    			case "XS":
    				this.Size = 2;
    				break;
    			case "S":
    				this.Size = 3;
    				break;
    			case "M":
    				this.Size = 4;
    				break;
    			case "L":
    				this.Size = 5;
    				break;
    		}
    	}
    
    	public string Name { get; set; }
    
    	public int Size { get; private set; }
    
    	public int Value { get; set; }
    }
    
    private static void Main(string[] args)
    {
    	List<Unit1> list1 = new List<Unit1>();
    	list1.Add(new Unit1("XS") { Value = 1 });
    	list1.Add(new Unit1("M") { Value = 1 });
    	list1.Add(new Unit1("S") { Value = 1 });
    	list1.Add(new Unit1("L") { Value = 1 });
    
    	var sortedList = list1.OrderBy(z => z.Size).ToList();
    }
